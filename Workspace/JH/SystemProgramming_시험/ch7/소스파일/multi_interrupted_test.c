//#include <stdio.h>
//#include <signal.h>
//#include <unistd.h>
//#include <unistd.h>
//#include <stdlib.h>

//void sig_handler(int sig)
//{
//    printf("hello world!!\n");
//    sleep(10);
//    printf("sig_handler\n)");
//    alarm(5);       //if there is not this line , The sigalrm is not arise again
//}

//void sig_handler2(int sig)
//{
//    printf("sig_handler2\n");

//}
//int main(void)
//{
//    int osig ;
//    printf("program start!!\n");


//    signal(SIGALRM , SIG_IGN);
//    osig = signal(SIGALRM , sig_handler);
//    osig = signal(SIGINT , sig_handler2);
//    alarm(5);

//    if(osig == SIG_IGN)
//    {
//        printf("SIG_IGN has set before setting sig_handler!!\n");
//    }

//    pause();

//    sleep(10);

//    return 0;

//}
