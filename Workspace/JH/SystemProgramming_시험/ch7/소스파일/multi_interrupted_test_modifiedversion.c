//#include <stdio.h>
//#include <signal.h>
//#include <unistd.h>
//#include <unistd.h>
//#include <stdlib.h>

//void sig_handler(int sig)
//{
//    printf("hello world!!\n");
//    sleep(3);
//    printf("sig_handler\n)");
////    alarm(5);       //if there is not this line , The sigalrm is not arise again
//}

//void sig_handler2(int sig)
//{
//    printf("sig_handler2\n");
//}
//int main(void)
//{
//    struct sigaction act ;
//    sigset_t set , check_set;
//    printf("program start!!\n");

//    act.sa_handler = sig_handler ;
//    sigemptyset(&act.sa_mask);
//    act.sa_flags = 0 ;

//    sigaction(SIGALRM , &act , NULL);

//    sigemptyset(&set);
//    sigaddset(&set , SIGINT);
//    sigprocmask(SIG_BLOCK, &set , NULL);

//    alarm(5);

//    pause();

//    sigemptyset(&check_set);
//    sigpending(&check_set);

//    if(sigismember(&check_set , SIGINT))
//    {
//        printf("SIGINT is called for handling sigalrm\n");
//    }
//    else
//    {
//        printf("Not called!!\n");
//    }

//    return 0;
//}
