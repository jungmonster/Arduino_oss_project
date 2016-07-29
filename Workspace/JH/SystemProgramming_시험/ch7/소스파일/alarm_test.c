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
//    int osig ;
//    printf("program start!!\n");


//    signal(SIGALRM , SIG_IGN);
//    osig = signal(SIGALRM , sig_handler);
//    alarm(5);

//    if(osig == SIG_IGN)
//    {
//        printf("SIG_IGN has set before setting sig_handler!!\n");
//    }

//    pause();

//    sleep(10);

//    return 0;

//}
