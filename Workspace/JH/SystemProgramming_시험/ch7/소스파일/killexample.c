#include <stdio.h>
#include <signal.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <errno.h>

pid_t child_pid = 0 ;
pid_t temp_child_pid = 0;

void sig_handler(int sig)
{
    if(child_pid != 0)
    {
        kill(child_pid , SIGUSR1);
        printf("Second sig_handler call!!\n");
    }
    else{
        printf("First sig_handler call!!\n");
        child_pid = temp_child_pid ;
    }
}

void sig_handler2(int sig)
{
    if(sig == SIGUSR1)
    {
        printf("Child process receive SIGINT signal\n");
        exit(1);
    }
}

int main(void)
{
    struct sigaction act ;
    int status = 0 ;
    pid_t pid ;

    pid = fork();

    if(pid == 0)
    {
        signal(SIGINT , SIG_IGN);
        act.sa_handler = sig_handler2 ;
        sigemptyset(&act.sa_mask);
        act.sa_flags = SA_RESTART ;
        sigaction(SIGUSR1 , &act , NULL);

        pause();
    }
    else
    {
        temp_child_pid = pid;
        act.sa_handler = sig_handler ;
        sigemptyset(&act.sa_mask);
//        act.sa_flags = 0;
        act.sa_flags = SA_RESTART ;
        sigaction(SIGINT , &act , NULL);

        wait(&status);

        if(WIFEXITED(status))
        {
            printf("Child process exited with %d status\n", WEXITSTATUS(status));
        }
    }

    return 0;
}
