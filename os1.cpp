// OS_Sim.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <thread>
#include <Windows.h>
#include <mutex>              // std::mutex, std::unique_lock
#include <condition_variable>

#define TIME_QUANTUM    5

#define PROCESS_READY   0
#define PROCESS_RUN     1
#define PROCESS_BLOCK   2

#define SCHED_IO_REQ            0
#define SCHED_QUANTUM_EXPIRED   1

#define NUMBER_OF_PRIORITY  5  
volatile int cur_proc;
std::condition_variable cv;
std::mutex cv_m;

struct proc_tbl_t {
    int id;
    int priority;
    int state;
    int time_quantum;
    int waiting_time;
    std::thread th;
    std::mutex mu_lock;
    struct proc_tbl_t* prev;
    struct proc_tbl_t* next;
} proc_tbl[10];

struct proc_tbl_t run_q[NUMBER_OF_PRIORITY]; //ready[0]~[4]
struct proc_tbl_t block_q;

void Put_Tail_Q(proc_tbl_t*, proc_tbl_t*);
proc_tbl_t* Get_Head_Q(proc_tbl_t* head);
void Print_Q(proc_tbl_t*);
void syscall_reqio();
void sys_timer_int();
void sys_scheduler(int why);

void IO_Completion_Interrupt(int id);
void proc_1(int id);
void proc_2(int id);
void proc_3(int id);
void proc_4(int id);
void proc_5(int id);

void Age_Q(proc_tbl_t*);
//aging 을 구현하기 위한 함수 선언

void proc_1(int id)
{
    int r;
    std::unique_lock<std::mutex> lk(cv_m);

    for (;;) {
        cv.wait(lk, [=] {return cur_proc == id; });
        std::cout << id << ' ';
        r = rand() % 100;
        if (r < 10) syscall_reqio();  // call IO with 10% probability
        else Sleep(10);
    }
}

void proc_2(int id)  // CPU-bound process, Do computation only, No IO Request
{
    std::unique_lock<std::mutex> lk(cv_m);

    for (;;) {
        cv.wait(lk, [=] {return cur_proc == id; });
        std::cout << id << ' ';
        Sleep(10);
    }
}

void proc_3(int id)
{
    int r;
    std::unique_lock<std::mutex> lk(cv_m);

    for (;;) {
        cv.wait(lk, [=] {return cur_proc == id; });
        std::cout << id << ' ';
        r = rand() % 100;
        if (r < 15) syscall_reqio();  // call IO with 15% probability
        else Sleep(10);
    }
}

void proc_4(int id)
{
    int r;
    std::unique_lock<std::mutex> lk(cv_m);

    for (;;) {
        cv.wait(lk, [=] {return cur_proc == id; });
        std::cout << id << ' ';
        r = rand() % 100;
        if (r < 90) syscall_reqio();  // call IO with 90% probability
        else Sleep(10);
        //다른 프로세스와 비교를 위해 IO를 매우 자주 호출하게끔 확률을 높였다.
    }
}

void proc_5(int id)
{
    int r;
    std::unique_lock<std::mutex> lk(cv_m);

    for (;;) {
        cv.wait(lk, [=] {return cur_proc == id; });
        std::cout << id << ' ';
        r = rand() % 100;
        if (r < 25) syscall_reqio();  // call IO with 25% probability
        else Sleep(10);
    }
}

int main()
{
    proc_tbl_t* p;
    for (int i = 0; i < NUMBER_OF_PRIORITY; i++) {
        run_q[i].next = run_q[i].prev = &(run_q[i]);
    }
    block_q.next = block_q.prev = &(block_q);
    cur_proc = -1;

    p = &(proc_tbl[0]);
    p->id = 0;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(IO_Completion_Interrupt, 0);
    //    Print_Q(&run_q);


    p = &(proc_tbl[1]);
    p->id = 1;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_1, 1);

    Put_Tail_Q(&run_q[0], p);
    //    Print_Q(&run_q);

    p = &(proc_tbl[2]);
    p->id = 2;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_2, 2);

    Put_Tail_Q(&run_q[0], p);
    //    Print_Q(&run_q);

    p = &(proc_tbl[3]);
    p->id = 3;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_3, 3);

    Put_Tail_Q(&run_q[0], p);
    //    Print_Q(&run_q);

    p = &(proc_tbl[4]);
    p->id = 4;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_4, 4);

    Put_Tail_Q(&run_q[0], p);

    p = &(proc_tbl[5]);
    p->id = 5;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_5, 5);

    Put_Tail_Q(&run_q[0], p);

    p = &(proc_tbl[6]);
    p->id = 6;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_2, 6);

    Put_Tail_Q(&run_q[0], p);

    p = &(proc_tbl[7]);
    p->id = 7;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_2, 7);

    Put_Tail_Q(&run_q[0], p);

    p = &(proc_tbl[8]);
    p->id = 8;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_2, 8);

    Put_Tail_Q(&run_q[0], p);

    p = &(proc_tbl[9]);
    p->id = 9;
    p->priority = 0;
    p->state = PROCESS_READY;
    p->waiting_time = 0;
    p->th = std::thread(proc_2, 9);

    Put_Tail_Q(&run_q[0], p);
    //Aging을 체크하기 위해 2, 6~9 는 cpu-bound process의 역할만을 수행한다.
        
        // The member function will be executed in a separate thread

        // Wait for the thread to finish, this is a blocking operation

        // Now Begin Schedule
    std::cout << " 2018920029 신원균 " << std::endl;
    sys_timer_int();

    return 0;
}

void syscall_reqio()
{
    // Invoke IO Operation, 
    // Then schedule to other process
    sys_scheduler(SCHED_IO_REQ);
}

void sys_timer_int()
{
    proc_tbl_t* p;

    for (;;) {
        /* do Time Service */
        if (cur_proc == -1) {
            sys_scheduler(SCHED_QUANTUM_EXPIRED);
        }
        else {
            p = &(proc_tbl[cur_proc]);
            p->time_quantum--;
            if (p->time_quantum <= 0)
                sys_scheduler(SCHED_QUANTUM_EXPIRED);
        }
        Sleep(100);
    }
}

void sys_scheduler(int why)
{
    proc_tbl_t* p;

    /* 학생들은 이 함수내에서 코드를 작성해야 한다 */

     // Aging 구현 (최하단의 Age_Q 코드안에 설명을 작성 했습니다)
    for (int i = 0; i < NUMBER_OF_PRIORITY; i++)
    {
        Age_Q(&run_q[i]);       // 각 우선순위의 레디큐마다 aging을 진행한다.
    }
    
    if (why == SCHED_IO_REQ) {
        // 가상 프로세스가  syscall_reqio() 를 호출한 경우
        if (cur_proc != -1) {
            //그 중 실행중인 프로세스가 있는 경우
            p = &(proc_tbl[cur_proc]);
            // 그 프로세스를 p에 저장하고
            p->state = PROCESS_BLOCK;
            // 프로세스의 상태를 block으로 만든후
            Put_Tail_Q(&block_q, p);
            // 블록큐의 맨뒤에 삽입
            std::cout << std::endl<<"IO need!, now priority : " << p->priority<< std::endl;
        }
        for (int i = 0;; i++) {
            p = Get_Head_Q(&run_q[i]);
            //각 priority의 레디큐의 원소를 높은 우선순위의 큐부터 조회한다.
            if (p != NULL) {
                // 만약 현재 priority의 레디큐에 원소가 존재하면 break한다.
                break;
            }
            if (i >= NUMBER_OF_PRIORITY) {
                // 만약 지정한 우선순위의 값보다 i값이 크거나 같다면 실행할 프로세스가
                // 없다는 뜻이므로 에러메세지를 출력한후 종료한다.
                cur_proc = -1;
                std::cout << "no process to exec" << std::endl;
                return;
            }
        }
        
        // 프로세스 실행
        cur_proc = p->id;
        p->state = PROCESS_RUN;
        p->time_quantum = TIME_QUANTUM;
        p->waiting_time = 0;

        
        //전체 상태 출력
        std::cout << std::endl<<"now whole state : " << std::endl;
        std::cout << "Block queue : ";
        Print_Q(&block_q);
        for (int i = 0; i < NUMBER_OF_PRIORITY; i++) {
            std::cout << i << " th prioriry Ready Queue : ";
            Print_Q(&run_q[i]);
        }
        //std::cout << std::endl;

        cv.notify_all();   // switch to process p->id and run */

    }
    else {
        // QUANTUM_EXPIRED 된 경우
        if (cur_proc != -1) {
            //그 중 실행한 프로세스가 있는 경우
            p = &(proc_tbl[cur_proc]);
            // 그 프로세스를 p에 저장하고
            p->state = PROCESS_READY;
            // 프로세스의 상태를 ready로 만든후
            p->priority++;
            // 우선순위를 낮춘다.(priority값을 높인다)
            if (p->priority >= NUMBER_OF_PRIORITY)
                p->priority--;
            //만약 이미 priority가 최대치라면 증가시키지 않는다.
            Put_Tail_Q(&run_q[p->priority], p);
            // 해당 우선순위의 레디큐 맨뒤에 삽입한다.
        }
        for (int i = 0;; i++) {
            p = Get_Head_Q(&run_q[i]);
            //각 priority의 레디큐의 원소를 높은 우선순위의 큐부터 조회한다.
            if (p != NULL) {
                // 만약 현재 priority의 레디큐에 원소가 존재하면 break한다.
                break;
            }
            if (i >= NUMBER_OF_PRIORITY) {
                // 만약 지정한 우선순위의 값보다 i값이 크거나 같다면 실행할 프로세스가
                // 없다는 뜻이므로 에러메세지를 출력한후 종료한다.
                cur_proc = -1;
                std::cout << "no process to exec" << std::endl;
                return;
            }
        }

        // 프로세스 실행
        cur_proc = p->id;
        p->state = PROCESS_RUN;
        p->time_quantum = TIME_QUANTUM;
        p->waiting_time = 0;

   

        //전체 상태 출력
        std::cout << std::endl << "now whole state : " << std::endl;
        std::cout << "Block queue : ";
        Print_Q(&block_q);
        for (int i = 0; i < NUMBER_OF_PRIORITY; i++) {
            std::cout << i << " th prioriry Ready Queue : ";
            Print_Q(&run_q[i]);
        }
        //std::cout << std::endl;

        cv.notify_all();   // switch to process p->id and run */
    }
    
}

/* IO Interrupt Generator */
void IO_Completion_Interrupt(int id)
{
    proc_tbl_t* p;
    for (;;) {

        /* 학생들은 이곳에 코드를 작성해야 한다 */
        p = Get_Head_Q(&block_q);
        //블락큐에서 제일 오래기다린 프로세스를 pop한다.
        if (p != NULL) {
            //블락큐가 비어있지 않다면 
            p->state = PROCESS_READY;
            // 프로세스의 상태를 레디로 변경하고
            Put_Tail_Q(&run_q[p->priority], p);
            //원래의 priority 레디큐에 추가해준다.
            std::cout << std::endl<< p->id << "'s IO complete!, now priority : " << p->priority << std::endl;
        }
        else {
            Sleep(500);   /* Wakeup in every 0.5 sec */
        }

    }
}

void Put_Tail_Q(proc_tbl_t* head, proc_tbl_t* item)
{
    (head->mu_lock).lock();
    item->prev = head->prev;
    head->prev->next = item;
    item->next = head;
    head->prev = item;
    (head->mu_lock).unlock();
}

proc_tbl_t* Get_Head_Q(proc_tbl_t* head)
{
    proc_tbl_t* item;

    (head->mu_lock).lock();
    if (head->next == head) {
        // 큐가 비어있다.
        (head->mu_lock).unlock();
        return NULL;
    }
    //제일 앞의 원소를 pop하는과정
    item = head->next;

    item->next->prev = head;
    head->next = item->next;

    (head->mu_lock).unlock();
    return item;
}

void Print_Q(proc_tbl_t* head)
{
    proc_tbl_t* item;

    item = head->next;
    while (item != head) {
        std::cout << item->id << ' ';
        item = item->next;
    }
    std::cout << '\n';
}

void Age_Q(proc_tbl_t* head)
{
    proc_tbl_t* item,* p;    
    item = head->next;
    //큐의 제일 앞원소를 item에 저장한다.
    while (item != head) {
        item->waiting_time++;
        //해당 원소의 wating time을 증가시킨다.
        if (item->waiting_time > 20) {
           
            // 만약 waiting time이 20을 넘겼다면 우선순위를 높여주고 wating time을 초기화 시켜준다
            // 해당 레벨의 레디큐의 제일 앞에 있는 원소가 그 큐안에서 제일 오래 기다렸으며 
            // 맨 앞의 원소부터 순서대로 item의 waiting time을 조사하기에
            // 맨 앞의 원소를 pop한뒤 한단계 높은 우선순위 큐로 push_back한다.
            if (item->priority > 0) {
                std::cout <<std::endl << " 2018920029 신원균 " << std::endl;
                std::cout <<  item->id << " is too old priority will be upgraded, now wait time : " << item->waiting_time << std::endl;
                int pri = item->priority;
                item = item->next;

                p = Get_Head_Q(&run_q[pri]);
                p->priority = p->priority - 1;
                p->waiting_time = 0;
                Put_Tail_Q(&run_q[p->priority], p);                
                continue;
                // item값을 이미 next로 바꿨으니 continue로 다음 반복을 시행한다.
            }
           
        }
        item = item->next;
        // 다음 원소로 item값을 변경한다.
    }   
    // item값이 head가 될때까지 반복해서 큐 전체원소의 aging을 진행한다.
}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁: 
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.
