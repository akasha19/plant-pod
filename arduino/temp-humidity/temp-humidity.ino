#include "DHT.h"

#define DHTPIN 2     // Pin 2 used by temp & humidity sensor
#define DHTTYPE DHT11   // Defines type of sensor
DHT dht(DHTPIN, DHTTYPE); // combines sensor data

//startup arduino
void setup() {
  Serial.begin(9600);
  Serial.println(F("Serial started"));

  dht.begin();
}

void loop() {
  delay(5000); //delay between loop (1 sec = 1000)
  float humidity = dht.readHumidity(); // reads humidity
  float temp = dht.readTemperature();   // Read temperature as Celsius

  // Checks if any sensor has failed
  if (isnan(humidity) || isnan(temp)) {
    Serial.println(F("Temp/humidity sensor failed!"));
    return;
  }

  // Compute heat index in Celsius
  float heatindex = dht.computeHeatIndex(temp, humidity, false);

  Serial.print(F("Humidity: "));
  Serial.print(humidity);
  Serial.print(F("%  Temperature: "));
  Serial.print(temp);
  Serial.print(F("°C "));
  Serial.print(F(" Heat index: "));
  Serial.print(heatindex);
  Serial.println(F("°C "));
}
