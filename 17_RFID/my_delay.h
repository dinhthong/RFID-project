#ifndef my_delay_h
#define my_delay_h
#include "stm32f4xx.h"


void delay_init(u8 SYSCLK);
void delay_us(uint32_t nus);
void delay_ms(uint32_t nms);

#endif