//#include <stdio.h>
//#include <signal.h>
//#include <unistd.h>
//#include <unistd.h>
//#include <stdlib.h>

//void sig_handler(int sig)
//{
//    printf("sig_handler\n");

//    alarm(3);       //if there is not this line , The sigalrm is not arise again
//}

//void sig_action(int sig , siginfo_t* pInfo , void* arg)
//{
//    printf("sig_action");
//}

//int main(void)
//{
//    struct sigaction act ;

//    act.sa_handler = sig_handler ;
//    act.sa_sigaction = sig_action;
//    sigemptyset(&act.sa_mask);

//    if(sigaddset(&act.sa_mask , SIGINT) == 0)
//    {
//       printf("signal mask setting success!!\n");
//    }
//    act.sa_flags = SA_SIGINFO;

//    printf("program start!!\n");

//    sigaction(SIGALRM , &act , 0);
//    sigprocmask(SIG_BLOCK , &act.sa_mask , 0);
//    alarm(3);

//    pause();

//    sleep(7);
//    return 0;

//}
