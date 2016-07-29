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
//}

//int main(void)
//{
//    struct sigaction act ;
//    printf("program start!!\n");

//    act.sa_handler = sig_handler ;
//    sigemptyset(&act.sa_mask);
//    act.sa_flags = SA_NODEFER ;
//    sigaction(SIGINT , &act , NULL);

//    pause();

//    return 0;

//}
