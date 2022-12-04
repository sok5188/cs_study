#include <avr/io.h>
#define F_CPU 16000000UL
#include <util/delay.h>
#include <avr/interrupt.h>

#define DO 7  // ��Ʈ E�� 7����

#define STOP 0
#define GO 1

volatile int count = 0;
volatile int stop_time = 0;
volatile int state = STOP; 

void buzzer(int hz, int count);
unsigned char digit[10] = {
  0x3f,
  0x06,
  0x5b,
  0x4f,
  0x66,
  0x6d,
  0x7c,
  0x07,
  0x7f,
  0x67
};
unsigned char fnd_sel[4] = {
  0x08,
  0x04,
  0x02,
  0x01
};

unsigned char fnd[4];

SIGNAL(SIG_INTERRUPT4) {
  	state = GO; // state �� Go�� �����ϰ� ������ ���� ������ 
	count = 0;
  	stop_time = 0;
}

SIGNAL(SIG_INTERRUPT5) {
  state = STOP; // �ʱ�ȭ, ����
	stop_time=count;
	//������ �ӽ÷� �׳� ���� count���� stoptime�� ����
	// ���ڿ� ���� ���� �ްԵǸ� stop-time�� �ִ밪���� ����
}

//set fnd with val
void set_light(int val){
	fnd[3]=val%10;
	fnd[2]=(val/10)%10;
	fnd[1]=(val/100)%10;
	fnd[0]=(val/1000)%10;
	int i=0;
	for (i = 0; i < 4; i++) {
      PORTC = digit[fnd[i]];
      PORTG = fnd_sel[i];
      _delay_ms(1);
    }
}

//set led with val
void set_leds(int val){
	int i=0;
	if(val<10){
        PORTA=0b00000001;
		
		for (i = 0; i < 3; i++) {
      		buzzer(240, 2);
      		buzzer(160,1);
    	}
	}else if(val<100){
        PORTA=0b00001111;
		for (i = 0; i < 3; i++) {
      		buzzer(360, 2);
      		buzzer(240,1);
    	}
    }else if(val < 1000){
        PORTA=0b11110000;
		for (i = 0; i < 3; i++) {
      		buzzer(480, 2);
      		buzzer(320,1);
    	}
    }else {
        PORTA=0b11111111;
    }
}

void init(){
	DDRC = 0xff;
  	DDRG = 0x0f;
  	DDRA = 0xff; // ��Ʈ A�� ��� ��Ʈ�� ���
	DDRB = 0x10;
  //E��Ʈ 4,5�� input���� ��� ?
  	DDRE = 0xcf;

	EICRB = 0x0a; //falling edge
 	EIMSK = 0x30; //interrupt en
 	SREG |= 1 << 7;
}

int main() {
 	init();
  while (1) {
    if (count == 10000)
      count = 0;
    //set_light(count);
	//_delay_ms(5);
	//set_leds(count);

	//int val=(int)PINE;
	//set_light(val);
	//set_leds(val);
	//_delay_ms(5);

	if(state==STOP){
	//���� ����� �ְ� ���ڿ� �󵵸� ǥ��(����� stop time�� ǥ��)
		while(state==STOP){
			set_light(stop_time);
			_delay_ms(3);

		}
	}
	else{
	//GO : ������
		set_light(count);
		set_leds(count);
		count++;
		//_delay_ms(3);
	}

  }
}

void buzzer(int hz, int count) {
  int i, ms, us;
  ms = (int)(500 / (float) hz);
  us = ((500 / (float) hz) - ms) * 1000;
  for (i = 0; i < count; i++) {

    PORTB = 0x10;
    //_delay_ms(ms);
    _delay_us(us);

    PORTB = 0x00;
   // _delay_ms(ms);
    _delay_us(us);
  }
}

