#include "stm32f4xx.h"
#include "mfrc522.h"
#include "my_delay.h"
uint8_t CompareID(uint8_t* CardID, uint8_t* CompareID);
void Read64Block( void);
void UARTmain_Init(void);
uint8_t status; uint8_t g_ucTempbuf[20];  bool flag_loop=0;
uint8_t defaultKeyA[16] = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
int main(void)
{
	//4 bytes = 32 bits
	uint8_t MyID[5] = {0x60,0xc8,0x11,0x7c};
    UARTmain_Init();
		 //cho phep USART2 hoat dong
		MF522_init();
		delay_init(168);
    MFRC522_Reset();
//    MFRC522_AntennaOff(); 
    MFRC522_AntennaOn();  
		printf("CHUONG TRINH RFID\r\n");
	 //Read64Block();
	while(1)
	{
		status = MFRC522_Request(PICC_REQALL, g_ucTempbuf);
    if (status != MI_OK)
    {  
		  flag_loop=0;  
      continue;
    }
		status = MFRC522_Anticoll(g_ucTempbuf);
    if (status != MI_OK)
         {  
					 flag_loop=0;  
           continue;
         }
	  if(flag_loop==1) 
        {
				 MFRC522_Halt();	
				 continue;
				}
		flag_loop=1;
		printf("\n UID=%x:%x:%x:%x\r\n",g_ucTempbuf[0],g_ucTempbuf[1],g_ucTempbuf[2],g_ucTempbuf[3] );
		MFRC522_Halt();
	  if (CompareID(g_ucTempbuf,MyID) == MI_OK) 
			{
		printf("Welcome! Card is correct\n");
			} 
		else 
			{
				printf(" Card is NOT correct\n");
			}
		//	printf("Read 64 sector\r\n");
     //  Read64Block();			
	}
}
uint8_t CompareID(uint8_t* CardID, uint8_t* CompareID) 
{
	uint8_t i;
	for (i = 0; i < 5; i++) {
		if (CardID[i] != CompareID[i]) 
			{
			return MI_ERR;
		  }
	}
	return MI_OK;
}

void Read64Block( void)
{
 uint8_t k=0,p=0;
 uint8_t  readdata[16];
 uint8_t serNum[5];
	  for(k=0;k<64;k++)			
	    {		
				 status = MFRC522_Request(PICC_REQALL, g_ucTempbuf);
         if (status != MI_OK) continue;
/*---------------------------------------------------*/				
         status = MFRC522_Anticoll(serNum);
         if (status != MI_OK) continue;
/*----------------------------------------------------*/
         status = MFRC522_Select(serNum);
         if (status != MI_OK) continue;
/*----------------------------------------------------*/
         status = MFRC522_AuthState(PICC_AUTHENT1A, k, defaultKeyA,serNum);
         if (status != MI_OK) continue;
/*----------------------------------------------------*/	
        if((k%4) == 3	)			printf("block  %d ( trailer) \r\n", k);
				else printf("block %d\r\n", k);	
				 status = MFRC522_Read(k, readdata);
                if (status == MI_OK)
                {
									printf("hex= ");
                  for(p=0; p<16; p++)
                  {                  
									printf("%x ",readdata[p]);
                  } 
                  printf("\r\nsymbol= ");	    								
                   /*for(p=0; p<16; p++)
                  {                  
										printf("%c",readdata[p]);
                  } 	*/
                  printf("\r\n\r\n");									        
                  MFRC522_Halt();
								//delay_ms(500);
              }
       }
}

void UARTmain_Init(void)
{
		GPIO_InitTypeDef GPIO_InitStruct;
    USART_InitTypeDef USART_InitStruct;
	  RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);
	
    //cho phep clock toi chan Rx Tx
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	
    //cau hinh chan Rx Tx PD5 PD6 chan con lai vao GND
    GPIO_InitStruct.GPIO_Mode=GPIO_Mode_AF;
    GPIO_InitStruct.GPIO_Pin=GPIO_Pin_5|GPIO_Pin_6;
    GPIO_InitStruct.GPIO_Speed=GPIO_Speed_100MHz;
    GPIO_InitStruct.GPIO_OType=GPIO_OType_PP;
    GPIO_InitStruct.GPIO_PuPd=GPIO_PuPd_UP;
    GPIO_Init(GPIOD, &GPIO_InitStruct);
	
    //gan chan Rx Tx
    GPIO_PinAFConfig(GPIOD, GPIO_PinSource5, GPIO_AF_USART2);
    GPIO_PinAFConfig(GPIOD, GPIO_PinSource6, GPIO_AF_USART2);
	
    //cau hinh cho USART2
    USART_InitStruct.USART_BaudRate=115200;
    USART_InitStruct.USART_HardwareFlowControl=USART_HardwareFlowControl_None;
    USART_InitStruct.USART_Mode=USART_Mode_Tx|USART_Mode_Rx;
    USART_InitStruct.USART_Parity=USART_Parity_No;
    USART_InitStruct.USART_StopBits=USART_StopBits_1;
    USART_InitStruct.USART_WordLength=USART_WordLength_8b;
    USART_Init(USART2, &USART_InitStruct);
		USART_Cmd(USART2, ENABLE);
}
