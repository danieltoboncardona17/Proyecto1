const int EchoPin = 5;
const int TriggerPin = 6;
 uint32_t lasttime = 0;
void setup() {
   Serial.begin(9600);
   pinMode(TriggerPin, OUTPUT);
   pinMode(EchoPin, INPUT);
}
 
void loop() {


  if (millis() > lasttime + 5)
  {
  int cm = ping(TriggerPin, EchoPin);
  int cm1=ping(TriggerPin, EchoPin);
  int cm2 = ping(TriggerPin, EchoPin);
  int cm3=ping(TriggerPin, EchoPin);
  int cm4 = ping(TriggerPin, EchoPin);
  
  int cmFinal= (cm+cm1+cm2+cm3+cm4)/5;
  cmFinal = cmFinal/5;
  if(cmFinal>=4){
    cmFinal= cmFinal;
  
  }else{
    cmFinal= -cmFinal;
    
    }
    if(cmFinal<=8){
   Serial.println(cmFinal);
   lasttime = millis();
    }

  }
   
}
 
int ping(int TriggerPin, int EchoPin) {
   long duration, distanceCm;
   
   digitalWrite(TriggerPin, LOW);  
   delayMicroseconds(4);
   digitalWrite(TriggerPin, HIGH); 
   delayMicroseconds(10);
   digitalWrite(TriggerPin, LOW);
   
   duration = pulseIn(EchoPin, HIGH); 
   
   distanceCm = duration * 10 / 292/ 2;   
   return distanceCm;
}
