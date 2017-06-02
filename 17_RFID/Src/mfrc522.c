#include "mfrc522.h" //this library includes the stm32f4xx.h
#include "my_delay.h" 

#define MAXRLEN    18

#define MF522_PORT_RST     GPIOA
#define MF522_PIN_RST      GPIO_Pin_3
#define MF522_RST_SET      GPIO_SetBits(MF522_PORT_RST,MF522_PIN_RST); //GPIO_SetBits(GPIOA,GPIO_Pin_3)
#define MF522_RST_RESET    GPIO_ResetBits(MF522_PORT_RST,MF522_PIN_RST);

#define MF522_PORT_CS      GPIOA
#define MF522_PIN_CS       GPIO_Pin_2
#define MF522_CS_ENABLE    GPIO_ResetBits(MF522_PORT_CS,MF522_PIN_CS); //SDA is CS pin
#define MF522_CS_DISABLE   GPIO_SetBits(MF522_PORT_CS,MF522_PIN_CS);

//Initilize the pinouts. GPIO for SPI AF
void MF522_init(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	SPI_InitTypeDef   SPI_InitStructure;

	//SDA: PA2 | SCK:PA5 | MOSI: PA7 | MISO: PA6 | RST: PA3

  /* Enable SCK, MOSI and MISO GPIO clocks and CS  GPIO clock*/
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);

  GPIO_PinAFConfig(GPIOA, GPIO_PinSource5, GPIO_AF_SPI1);
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource6, GPIO_AF_SPI1);
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource7, GPIO_AF_SPI1);

  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;

  /* SPI SCK pin configuration */
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  /* SPI  MOSI pin configuration */
  GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_7;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  /* SPI MISO pin configuration */
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

  /* Configure GPIO PIN for Chip select and nss */
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2|GPIO_Pin_3;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_Init(GPIOA, &GPIO_InitStructure);

	/* Enable the SPI periph */
	  RCC_APB2PeriphClockCmd(RCC_APB2Periph_SPI1, ENABLE);
  /* SPI configuration -------------------------------------------------------*/
    SPI_I2S_DeInit(SPI1);
    SPI_InitStructure.SPI_Direction = SPI_Direction_2Lines_FullDuplex;
    SPI_InitStructure.SPI_DataSize = SPI_DataSize_8b;
    SPI_InitStructure.SPI_CPOL = SPI_CPOL_Low;
    SPI_InitStructure.SPI_CPHA = SPI_CPHA_1Edge;
    SPI_InitStructure.SPI_NSS = SPI_NSS_Soft;
    SPI_InitStructure.SPI_BaudRatePrescaler = SPI_BaudRatePrescaler_8;
    SPI_InitStructure.SPI_FirstBit = SPI_FirstBit_MSB;
    SPI_InitStructure.SPI_CRCPolynomial = 7;
    SPI_InitStructure.SPI_Mode = SPI_Mode_Master;
    SPI_Init(SPI1, &SPI_InitStructure);
    /* Enable SPI1  */
    SPI_Cmd(SPI1, ENABLE);
}

unsigned char SPI_transfer(unsigned char data){

	uint32_t val;
	//This function is just exactly the same as void 'SPI_I2S_SendData(SPI_TypeDef* SPIx, uint16_t Data)'
	SPI1->DR = data; // write data to be transmitted to the SPI data register
	while( !(SPI1->SR & SPI_I2S_FLAG_TXE) ); // wait until transmit complete
	while( !(SPI1->SR & SPI_I2S_FLAG_RXNE) ); // wait until receive complete
	while( SPI1->SR & SPI_I2S_FLAG_BSY ); // wait until SPI is not busy anymore
	return SPI1->DR; // return received data from SPI data register
}

uint8_t MFRC522_Reset(void)
{
	MF522_CS_DISABLE;
  delay_us(8000);
	MF522_RST_RESET;
  delay_us(1000);
	MF522_RST_SET;
  delay_us(1000);
  MFRC522_WriteRegister(COMMAND_REGISTER,MFRC522_RESETPHASE);
  delay_us(1000);
    
  MFRC522_WriteRegister(MODE_REGISTER,0x3D);        
  MFRC522_WriteRegister(TIMER_RELOAD_L_REGISTER,30);           
  MFRC522_WriteRegister(TIMER_RELOAD_H_REGISTER,0);
  MFRC522_WriteRegister(TMODE_REGISTER,0x8D); //Tauto=1; f(Timer) = 6.78MHz/TPreScaler
  MFRC522_WriteRegister(TIMER_PRESCALER_REGISTER,0x3E);
  MFRC522_WriteRegister(TX_ASK_REGISTER,0x40);
   
  return MI_OK;
}
uint8_t MFRC522_ReadRegister(uint8_t Address)
{
  uint8_t val;
	MF522_CS_ENABLE;
	delay_us(5);
	//address format:1XXXXXX0
	SPI_transfer(((Address<<1)&0x7E) | 0x80);
	val = SPI_transfer(0x00);
	MF522_CS_DISABLE;
	delay_us(5);
	return val;
}
void MFRC522_WriteRegister(uint8_t Address, uint8_t value)
{  
	MF522_CS_ENABLE;
	delay_us(5);
	//address format:0XXXXXX0
	SPI_transfer((Address<<1)&0x7E);
	SPI_transfer(value);
	MF522_CS_DISABLE;
	delay_us(5);
}

/*******************************************************************************
Noi Dung    :   Yeu cau de tim Card nam trong vung hoat dong.
Tham Bien   :   Req_Code    :    Ma lenh.
                *pTagType   :    
Tra Ve      :   OK          :    Co tim thay thiet bi.
                NOT_OK      :    Chua tim thay thiet bi.
********************************************************************************/

uint8_t MFRC522_Request(uint8_t req_code,uint8_t* pTagType)
{
   uint8_t status=MI_ERR;  
   uint16_t  Length;
   uint8_t Buffer[MAXRLEN]; 

   ClearBitMask(STATUS2_REGISTER,0x08);
   MFRC522_WriteRegister(BIT_FRAMING_REGISTER,0x07);
   SetBitMask(TX_CONTROL_REGISTER,0x03);
   Buffer[0] = req_code;
   status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,1,Buffer,&Length);
   if ((status == MI_OK) && (Length == 0x10))
   {    
       *pTagType     = Buffer[0];
       *(pTagType+1) = Buffer[1];
   }
   else
   {   
       status = MI_ERR;   
   }
   return status;
} 
/*******************************************************************************
Noi Dung    :   Chong lap cai cac thiet bi, Lay Serial Number
Tham Bien   :   *pSnr       :    Vung nho luu tru Serial Number
Tra Ve      :   OK          :    Thanh cong.
                NOT_OK      :    That bai.
********************************************************************************/

uint8_t MFRC522_Anticoll(uint8_t *pSnr)
{
    uint8_t status;
    uint8_t i,snr_check=0;
    uint16_t  Length;
    uint8_t Buffer[MAXRLEN]; 
    

    ClearBitMask(STATUS2_REGISTER,0x08);
    MFRC522_WriteRegister(BIT_FRAMING_REGISTER,0x00);
    ClearBitMask(COLLISION_REGISTER,0x80);
 
    Buffer[0] = PICC_ANTICOLL1;
    Buffer[1] = 0x20;

    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,2,Buffer,&Length);

    if (status == MI_OK)
    {
        for (i=0; i<4; i++)
         {   
             *(pSnr+i)  = Buffer[i];
             snr_check ^= Buffer[i];
         }
         if (snr_check != Buffer[i])
         {   status = MI_ERR;    }
    }
    
    SetBitMask(COLLISION_REGISTER,0x80);
    return status;
}
/*******************************************************************************
Noi Dung    :   Chon mot Card de giao tiep
Tham Bien   :   *pSnr       :    Vung nho luu tru Serial Number Card can giao tiep
Tra Ve      :   OK          :    Giao tiep thanh cong.
                NOT_OK      :    Giao tiep that bai.
********************************************************************************/
uint8_t MFRC522_Select(uint8_t *pSnr)
{
    uint8_t status;
    uint8_t i;
    uint16_t  Length;
    uint8_t Buffer[MAXRLEN]; 
    
    Buffer[0] = PICC_ANTICOLL1;
    Buffer[1] = 0x70;
    Buffer[6] = 0;
    for (i=0; i<4; i++)
    {
       Buffer[i+2] = *(pSnr+i);
       Buffer[6]  ^= *(pSnr+i);
    }
    CalulateCRC(Buffer,7,&Buffer[7]);
  
    ClearBitMask(STATUS2_REGISTER,0x08);

    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,9,Buffer,&Length);
    
    if ((status == MI_OK) && (Length == 0x18))
    {   status = MI_OK;  }
    else
    {   status = MI_ERR;    }

    return status;
}
/**************************************************************************************
Byte 0     :    Authen Code
Byte 1     :    Block Addr
Byte 2-7   :    Sector Key Byte 0 - 5  
Byte 8-11  :    Card Serial Number Byte 0 - 4
**************************************************************************************/
uint8_t MFRC522_AuthState(uint8_t auth_mode,uint8_t addr,uint8_t *pKey,uint8_t *pSnr)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t i,Buffer[MAXRLEN]; 

    Buffer[0] = auth_mode;
    Buffer[1] = addr;
    for (i=0; i<6; i++)
    {    
          Buffer[i+2] = *(pKey+i);   }
    for (i=0; i<4; i++)
    {    Buffer[i+8] = *(pSnr+i);   }    
    status = MFRC522_ComMF522(MFRC522_AUTHENT,Buffer,12,Buffer,&Length);
    if ((status != MI_OK) || (!(MFRC522_ReadRegister(STATUS2_REGISTER) & 0x08)))
    {   status = MI_ERR;   }
    
    return status;
}
/*******************************************************************************
Noi Dung    :   Doc du lieu tu mot Block
Tham Bien   :   addr        :    Dia chi cua Block.
                *pData      :    Con tro luu tru du lieu.
Tra Ve      :   OK          :    Doc du lieu thanh cong.
                NOT_OK      :    Doc du lieu that bai.
********************************************************************************/
uint8_t MFRC522_Read(uint8_t addr,uint8_t *pData)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t i,Buffer[MAXRLEN]; 

    Buffer[0] = PICC_READ;
    Buffer[1] = addr;
    CalulateCRC(Buffer,2,&Buffer[2]);
   
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);
    if ((status == MI_OK) && (Length == 0x90))
    {
        for (i=0; i<16; i++)
        {    *(pData+i) = Buffer[i];   }
    }
    else
    {   status = MI_ERR;   }
    
    return status;
}  
/*******************************************************************************
Noi Dung    :   Ghi du lieu vao mot Block
Tham Bien   :   addr        :    Dia chi cua Block.
                *pData      :    Con tro luu tru du lieu.
Tra Ve      :   OK          :    Ghi du lieu thanh cong.
                NOT_OK      :    Ghi du lieu that bai.
********************************************************************************/
uint8_t MFRC522_Write(uint8_t addr,uint8_t *pData)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t i,Buffer[MAXRLEN]; 
    
    Buffer[0] = PICC_WRITE;
    Buffer[1] = addr;
    CalulateCRC(Buffer,2,&Buffer[2]);
 
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

    if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
    {   status = MI_ERR;   }
        
    if (status == MI_OK)
    {
        for (i=0; i<16; i++)
        {    Buffer[i] = *(pData+i);   }
        CalulateCRC(Buffer,16,&Buffer[16]);

        status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,18,Buffer,&Length);
        if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
        {   status = MI_ERR;   }
    }
    
    return status;
} 

uint8_t MFRC522_Value(uint8_t dd_mode,uint8_t addr,uint8_t *pValue)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t i,Buffer[MAXRLEN]; 
    
    Buffer[0] = dd_mode;
    Buffer[1] = addr;
    CalulateCRC(Buffer,2,&Buffer[2]);
 
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

    if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
    {   status = MI_ERR;   }
        
    if (status == MI_OK)
    {
        for (i=0; i<16; i++)
        {    Buffer[i] = *(pValue+i);   }
        CalulateCRC(Buffer,4,&Buffer[4]);
        Length = 0;
        status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,6,Buffer,&Length);
        if (status != MI_ERR)
        {    status = MI_OK;    }
    }
    
    if (status == MI_OK)
    {
        Buffer[0] = PICC_TRANSFER;
        Buffer[1] = addr;
        CalulateCRC(Buffer,2,&Buffer[2]); 
   
        status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

        if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
        {   status = MI_ERR;   }
    }
    return status;
}
uint8_t MFRC522_BakValue(uint8_t sourceaddr, uint8_t goaladdr)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t Buffer[MAXRLEN]; 

    Buffer[0] = PICC_RESTORE;
    Buffer[1] = sourceaddr;
    CalulateCRC(Buffer,2,&Buffer[2]);
 
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

    if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
    {   status = MI_ERR;   }
    
    if (status == MI_OK)
    {
        Buffer[0] = 0;
        Buffer[1] = 0;
        Buffer[2] = 0;
        Buffer[3] = 0;
        CalulateCRC(Buffer,4,&Buffer[4]);
 
        status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,6,Buffer,&Length);
        if (status != MI_ERR)
        {    status = MI_OK;    }
    }
    
    if (status != MI_OK)
    {    return MI_ERR;   }
    
    Buffer[0] = PICC_TRANSFER;
    Buffer[1] = goaladdr;

    CalulateCRC(Buffer,2,&Buffer[2]);
 
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

    if ((status != MI_OK) || (Length != 4) || ((Buffer[0] & 0x0F) != 0x0A))
    {   status = MI_ERR;   }

    return status;
}
uint8_t MFRC522_Halt(void)
{
    uint8_t status;
    uint16_t  Length;
    uint8_t Buffer[MAXRLEN]; 

    Buffer[0] = PICC_HALT;
    Buffer[1] = 0;
    CalulateCRC(Buffer,2,&Buffer[2]);
 
    status = MFRC522_ComMF522(MFRC522_TRANSCEIVE,Buffer,4,Buffer,&Length);

    return MI_OK;
}
void CalulateCRC(uint8_t *pIndata,uint8_t len,uint8_t *pOutData)
{
    uint8_t i,n;
    ClearBitMask(DIV_IRQ_REGISTER,0x04);
    MFRC522_WriteRegister(COMMAND_REGISTER,MFRC522_IDLE);
    SetBitMask(FIFO_LEVEL_REGISTER,0x80);
    for (i=0; i<len; i++)
    {   MFRC522_WriteRegister(FIFO_DATA_REGISTER, *(pIndata+i));   }
    MFRC522_WriteRegister(COMMAND_REGISTER, MFRC522_CALCCRC);
    i = 0xFF;
    do 
    {
        n = MFRC522_ReadRegister(DIV_IRQ_REGISTER);
        i--;
    }
    while ((i!=0) && !(n&0x04));
    pOutData[0] = MFRC522_ReadRegister(CRC_RESULT_L_REGISTER);
    pOutData[1] = MFRC522_ReadRegister(CRC_RESULT_M_REGISTER);
}

void SetBitMask(uint8_t reg,uint8_t mask)  
{
    uint8_t tmp = 0x0;
    tmp = MFRC522_ReadRegister(reg);
    MFRC522_WriteRegister(reg,tmp | mask);  // set bit mask
}
void ClearBitMask(uint8_t reg,uint8_t mask)  
{
    uint8_t tmp = 0x0;
    tmp = MFRC522_ReadRegister(reg);
    MFRC522_WriteRegister(reg, tmp & (~mask));  // clear bit mask
} 
uint8_t MFRC522_ComMF522(uint8_t  Command, uint8_t  *pInData, uint8_t  InLenByte,uint8_t  *pOutData, uint16_t *pOutLenBit)
{
    uint8_t status = MI_ERR;
    uint8_t irqEn   = 0x00;
    uint8_t waitFor = 0x00;
    uint8_t lastBits;
    uint8_t n;
    uint16_t i;
    switch (Command)
    {
       case MFRC522_AUTHENT:
          irqEn   = 0x12;
          waitFor = 0x10;
          break;
       case MFRC522_TRANSCEIVE:
          irqEn   = 0x77;
          waitFor = 0x30;
          break;
       default:
         break;
    }
   
    MFRC522_WriteRegister(IE_REGISTER,irqEn|0x80);
    ClearBitMask(IRQ_REGISTER,0x80);
    MFRC522_WriteRegister(COMMAND_REGISTER,MFRC522_IDLE);
    SetBitMask(FIFO_LEVEL_REGISTER,0x80);
    
    for (i=0; i<InLenByte; i++)
    {   
        MFRC522_WriteRegister(FIFO_DATA_REGISTER, pInData[i]);
    }
    MFRC522_WriteRegister(COMMAND_REGISTER, Command);
    if (Command == MFRC522_TRANSCEIVE)
    {    SetBitMask(BIT_FRAMING_REGISTER,0x80);  }
    
    i = 600;//25ms
    do 
    {
         n = MFRC522_ReadRegister(IRQ_REGISTER);
         i--;
    }
    while ((i!=0) && !(n&0x01) && !(n&waitFor));
    ClearBitMask(BIT_FRAMING_REGISTER,0x80);
         
    if (i!=0)
    {    
         if(!(MFRC522_ReadRegister(ERROR_REGISTER)&0x1B))
         {
             status = MI_OK;
             if (n & irqEn & 0x01)
             {   
                status = MI_NOTAGERR;   
             }
                   if (Command == MFRC522_TRANSCEIVE)
              {
                    n = MFRC522_ReadRegister(FIFO_LEVEL_REGISTER);
                   lastBits = MFRC522_ReadRegister(CONTROL_REGISTER) & 0x07;
                  if (lastBits)
                  {   
                      *pOutLenBit = (n-1)*8 + lastBits;  
                  }
                  else
                  {   
                      *pOutLenBit = n*8;   
                  }
                  if (n == 0)
                  {   
                      n = 1;    
                  }
                  if (n > MAXRLEN)
                  {   
                      n = MAXRLEN;   
                  }
                  for (i=0; i<n; i++)
                  {   
                      pOutData[i] = MFRC522_ReadRegister(FIFO_DATA_REGISTER);    
                  }
               }
         }
         else
         {   
            status = MI_ERR;   
         }      
   }
   SetBitMask(CONTROL_REGISTER,0x80);                    // stop timer now
   MFRC522_WriteRegister(COMMAND_REGISTER,MFRC522_IDLE); 
   return status;
}
void MFRC522_AntennaOn()
{
    uint8_t i;
    i = MFRC522_ReadRegister(TX_CONTROL_REGISTER);
    if (!(i & 0x03))
    {
        SetBitMask(TX_CONTROL_REGISTER, 0x03);
    }
}
void MFRC522_AntennaOff()
{
    ClearBitMask(TX_CONTROL_REGISTER, 0x03);
}
void dumpHex(uint8_t* buffer, int len){
	unsigned char i;
  for(i=0; i < len; i++) {
     uint8_t text[4];
     if (i % 16 == 0) {
        printf(" ");
     }
     printf("%02X \x00", (uint8_t)(*(buffer + i)));
     //Serial_print(text);

     if (i % 16 == 15) {
       printf("\r\n");
     }
  }
  //Serial_println(" ");
}
