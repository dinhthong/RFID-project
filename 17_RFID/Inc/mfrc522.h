#ifndef __MFRC522_H
#define __MFRC522_H

#include <stdbool.h>
#include <stdint.h>
#include "stm32f4xx.h" //include for library use

void MF522_init(void);
unsigned char SPI_transfer(unsigned char data);
uint8_t MFRC522_Reset(void);
void MFRC522_AntennaOn(void);
void MFRC522_AntennaOff(void);
uint8_t MFRC522_Request(uint8_t req_code,uint8_t *pTagType);   
uint8_t MFRC522_Anticoll(uint8_t *pSnr);
uint8_t MFRC522_Select(uint8_t *pSnr);         
uint8_t MFRC522_AuthState(uint8_t auth_mode,uint8_t addr,uint8_t *pKey,uint8_t *pSnr);     
uint8_t MFRC522_Read(uint8_t addr,uint8_t *pData);     
uint8_t MFRC522_Write(uint8_t addr,uint8_t *pData);    
uint8_t MFRC522_Value(uint8_t dd_mode,uint8_t addr,uint8_t *pValue);   
uint8_t MFRC522_BakValue(uint8_t sourceaddr, uint8_t goaladdr);                                 
uint8_t MFRC522_Halt(void);
uint8_t MFRC522_ComMF522(uint8_t Command, 
                 uint8_t *pInData, 
                 uint8_t InLenByte,
                 uint8_t *pOutData, 
                 uint16_t  *pOutLenBit);
void CalulateCRC(uint8_t *pIndata,uint8_t len,uint8_t *pOutData);
void MFRC522_WriteRegister(uint8_t Address,uint8_t value);
uint8_t MFRC522_ReadRegister(uint8_t Address); 
void SetBitMask(uint8_t reg,uint8_t mask); 
void ClearBitMask(uint8_t reg,uint8_t mask); 
void dumpHex(uint8_t* buffer, int len);

/*********************************************************************************
*********************************************************************************/
#define     MFRC522_IDLE              0x00               
#define     MFRC522_AUTHENT           0x0E               
#define     MFRC522_RECEIVE           0x08               
#define     MFRC522_TRANSMIT          0x04               
#define     MFRC522_TRANSCEIVE        0x0C               
#define     MFRC522_RESETPHASE        0x0F               
#define     MFRC522_CALCCRC           0x03               


#define     PICC_REQIDL           0x26               
#define     PICC_REQALL           0x52               
#define     PICC_ANTICOLL1        0x93               
#define     PICC_ANTICOLL2        0x95               
#define     PICC_AUTHENT1A        0x60               
#define     PICC_AUTHENT1B        0x61               
#define     PICC_READ             0x30               
#define     PICC_WRITE            0xA0               
#define     PICC_DECREMENT        0xC0               
#define     PICC_INCREMENT        0xC1               
#define     PICC_RESTORE          0xC2               
#define     PICC_TRANSFER         0xB0               
#define     PICC_HALT             0x50               


#define     DEF_FIFO_LENGTH          64                 //FIFO size=64byte


// PAGE 0
#define     RFU00                       0x00    
#define     COMMAND_REGISTER            0x01    
#define     IE_REGISTER                 0x02    
#define     DIV_IE_REGISTER             0x03    
#define     IRQ_REGISTER                0x04    
#define     DIV_IRQ_REGISTER            0x05
#define     ERROR_REGISTER              0x06    
#define     STATUS1_REGISTER            0x07    
#define     STATUS2_REGISTER            0x08    
#define     FIFO_DATA_REGISTER          0x09
#define     FIFO_LEVEL_REGISTER         0x0A
#define     WATER_LEVEL_REGISTER        0x0B
#define     CONTROL_REGISTER            0x0C
#define     BIT_FRAMING_REGISTER        0x0D
#define     COLLISION_REGISTER          0x0E
#define     RFU0F                       0x0F
// PAGE 1     
#define     RFU10                       0x10 //mfrc522 mannual 36/95
#define     MODE_REGISTER               0x11
#define     TX_MODE_REGISTER            0x12
#define     RX_MODE_REGISTER            0x13 //mfrc522 mannual 9.3.2.4
#define     TX_CONTROL_REGISTER         0x14
#define     TX_ASK_REGISTER             0x15
#define     TX_SEL_REGISTER             0x16
#define     RX_SEL_REGISTER             0x17
#define     RX_THRESHOLD_REGISTER       0x18
#define     DEMOD_REGISTER              0x19
#define     RFU1A                       0x1A
#define     RFU1B                       0x1B
#define     MIFARE_REGISTER             0x1C
#define     RFU1D                       0x1D
#define     RFU1E                       0x1E
#define     SERIAL_SPEED_REGISTER       0x1F
// PAGE 2    
#define     RFU20                       0x20  
#define     CRC_RESULT_M_REGISTER       0x21
#define     CRC_RESULT_L_REGISTER       0x22
#define     RFU23                       0x23
#define     MOD_WIDTH_REGISTER          0x24
#define     RFU25                       0x25
#define     RF_CONFIG_REGISTER          0x26
#define     GSN_REGISTER                0x27
#define     CWF_CONFIG_REGISTER         0x28
#define     MODGS_CONFIG_REGISTER       0x29
#define     TMODE_REGISTER              0x2A
#define     TIMER_PRESCALER_REGISTER    0x2B
#define     TIMER_RELOAD_H_REGISTER     0x2C
#define     TIMER_RELOAD_L_REGISTER     0x2D
#define     TIMER_VALUE_H_REGISTER      0x2E
#define     TIMER_VALUE_L_REGISTER      0x2F
// PAGE 3      
#define     RFU30                       0x30
#define     TEST_SEL_1_REGISTER         0x31
#define     TEST_SEL_2_REGISTER         0x32
#define     TEST_PIN_EN_REGISTER        0x33
#define     TEST_PIN_VALUE_REGISTER     0x34
#define     TEST_BUS_REGISTER           0x35
#define     AUTO_TEST_REGISTER          0x36
#define     VERSION_REGISTER            0x37
#define     ANALOG_TEST_REGISTER        0x38
#define     TEST_ADC1_REGISTER          0x39  
#define     TEST_ADC2_REGISTER          0x3A   
#define     TEST_ADC_REGISTER           0x3B   
#define     RFU3C                       0x3C   
#define     RFU3D                       0x3D   
#define     RFU3E                       0x3E   
#define     RFU3F                          0x3F

#define     MI_OK                       0
#define     MI_NOTAGERR                 1
#define     MI_ERR                      2

#endif
