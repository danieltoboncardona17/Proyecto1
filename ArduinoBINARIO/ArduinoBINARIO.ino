uint32_t last_time = 0;
const int buttonPin = 17;
int buttonState = 0;
uint32_t lasttime = 0;

void setup()
{
  Serial.begin(9600);
  pinMode(buttonPin, INPUT);
}

void loop()
{
  if (millis() > lasttime +800)
  {
  byte buff[1] = {0x00}; //
   buttonState = digitalRead(buttonPin);
if (buttonState == HIGH)
  {
   
      buff[0] = 0x01;
    

      Serial.write(buff, 1);
      
     
    
  }
  if(buttonState == LOW){
     buff[0] = 0x02;
    Serial.write(buff, 1);
    }
lasttime = millis();
  }

}

  
 

  // Print a heartbeat
  
