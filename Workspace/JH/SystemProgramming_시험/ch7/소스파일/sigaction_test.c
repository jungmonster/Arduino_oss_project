//#include <stdio.h>
//#include <signal.h>
//#include <unistd.h>
//#include <unistd.h>
//#include <stdlib.h>

//void sig_handler(int sig)
//{
//    printf("hello world!!\n");

//    alarm(5);       //if there is not this line , The sigalrm is not arise again
//    return 0;
//}

//int main(void)
//{
//    struct sigaction act ;

//    act.sa_handler = sig_handler ;
//    sigemptyset(&act.sa_mask);

//    if(sigaddset(&act.sa_mask , SIGINT) == 0)
//    {
//       printf("signal mask setting success!!\n");
//    }

//    act.sa_flags = SA_RESETHAND;

//    printf("program start!!\n");

//    sigaction(SIGALRM , &act , 0);
//    sigprocmask(SIG_BLOCK , &act.sa_mask , 0);
//    alarm(5);


//    pause();

//    sleep(10);

//    return 0;

//}
