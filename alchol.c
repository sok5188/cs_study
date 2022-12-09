#include <avr/io.h>
#define F_CPU 16000000UL
#include <util/delay.h>
#include <avr/interrupt.h>

#define DO 7  // 포트 E의 7번핀

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
  	state = GO; // state 를 Go로 변경하고 측정을 새로 시작함 
	count = 0;
  	stop_time = 0;
}

SIGNAL(SIG_INTERRUPT5) {
  state = STOP; // 초기화, 리셋
	stop_time=count;
	//지금은 임시로 그냥 현재 count값을 stoptime에 저장
	// 알코올 측정 값을 받게되면 stop-time을 최대값으로 저장
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
void init_adc() {
  ADMUX = 0x00;
  // REFS(1:0) = "00" AREF(+5V) 기준전압 사용
  // ADLAR = '0' 디폴트 오른쪽 정렬
  // MUX(4:0) = "00000" ADC0 사용, 단일 입력
  ADCSRA = 0x87;
  // ADEN = '1' ADC Enable
  // ADFR = '0' single conversion 모드
  // ADPS(2:0) = "111" 프리스케일러 128분주
}

unsigned short read_adc() {
  unsigned char adc_low, adc_high;
  unsigned short value;
  ADCSRA |= 0x40; // ADC start conversion, ADSC = '1'
  while ((ADCSRA & 0x10) != 0x10) // ADC 변환 완료 검사
  ;
  adc_low = ADCL; // 변환된 Low 값 읽어오기
  adc_high = ADCH; // 변환된 High 값 읽어오기
  value = (adc_high << 8) | adc_low;
  // value 는 High 및 Low 연결한 16비트값
  return value;
}

void init(){
	DDRC = 0xff;
  	DDRG = 0x0f;
  	DDRA = 0xff; // 포트 A를 출력 포트로 사용
	DDRB = 0x10;
  //E포트 4,5를 input으로 사용 ?
  	DDRE = 0xcf;

	EICRB = 0x0a; //falling edge
 	EIMSK = 0x30; //interrupt en
 	SREG |= 1 << 7;
	init_adc();
}

int main() {
 	init();
  while (1) {
	  int val=read_adc();
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
	//측정 종료시 최고 알코올 농도를 표시(현재는 stop time만 표시)
		while(state==STOP){
			set_light(stop_time);
			_delay_ms(3);

		}
	}
	else{
	//GO : 측정중
		set_light(val);
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

