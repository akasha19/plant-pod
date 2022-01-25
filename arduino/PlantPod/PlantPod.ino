#include <ArduinoJson.h>
#include <Ethernet.h>
#include <SPI.h>
#include "DHT.h"
#include"AirQuality.h"
#include"Arduino.h"

// Defines the temparature/humidity sensor
#define DHTPIN 2     
#define DHTTYPE DHT11  
DHT dht(DHTPIN, DHTTYPE); 

int SoilPin = A1;
int Soil = 0;

AirQuality airqualitysensor;
float current_quality =-1;


EthernetClient client;
byte mac[] = {0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED};
const char* server = "192.168.68.101";
int portNumber = 8588;
const char* resource = "/sensors";

const unsigned long HTTP_TIMEOUT = 10000;  
const size_t MAX_CONTENT_SIZE = 512;       

// only runs once on startup
void setup() {
  Serial.begin(9600);
  while(!Serial) {
    ;  
  }
  Serial.println("Serial ready");
  
  // temparature/humidity sensor startup
  dht.begin();

  if(!Ethernet.begin(mac)) {
    Serial.println("Failed to configure Ethernet");
    return;
  }
  Serial.println("Ethernet ready");
  airqualitysensor.init(A0);
  delay(1000);
}

// endless loop
void loop() {
 current_quality=airqualitysensor.slope();
  // make connection to the website and send the data
  if(connect(server, portNumber)) {
    if(sendRequest(server, resource) && skipResponseHeaders()) {
        while(client.connected() && !client.available()) delay(1); //waits for data
  while (client.connected() || client.available()) {
    char c = client.read();
    Serial.print(c);
  }
      Serial.print("HTTP POST request finished.");
    }
  }
  disconnect();
  wait();
}

bool connect(const char* hostName, int portNumber) {
  Serial.print("Connect to ");
  Serial.println(hostName);

  int ok = client.connect(hostName, portNumber);
  Serial.println(ok ? "Connected" : "Connection Failed!");
  return ok;
}

bool sendRequest(const char* host, const char* resource) {
   float temp = dht.readTemperature();   // Read temperature as Celsius
   float humidity = dht.readHumidity();
  float Soil = analogRead(SoilPin);
 

    
  StaticJsonBuffer<200> jsonBuffer;
  JsonObject& root = jsonBuffer.createObject();
  root["id"] = "196db225-e5ef-4636-b967-c214a0ddb73f";
  root["temperature"] = temp;
  root["humidity"] = humidity;
  root["moisture"] = Soil;
  root["air"] = current_quality;
  
  
  root.printTo(Serial);
  Serial.print("POST ");
  Serial.println(resource);

  client.print("POST ");
  client.print(resource);
  client.println(" HTTP/1.1");
  client.print("Host: ");
  client.println(host);
  client.println("Connection: close\r\nContent-Type: application/json");
  client.print("Content-Length: ");
  client.print(root.measureLength());
  client.print("\r\n");
  client.println();
  root.printTo(client);

  return true;
}

// Skip HTTP headers so that we are at the beginning of the response's body
bool skipResponseHeaders() {
  // HTTP headers end with an empty line
  char endOfHeaders[] = "\r\n\r\n";

  client.setTimeout(HTTP_TIMEOUT);
  bool ok = client.find(endOfHeaders);

  if(!ok) {
    Serial.print("No response or invalid response! Error code: ");
    Serial.println(ok);
  }
  return ok;
}

void disconnect() {
  Serial.println("Disconnect");
  client.stop();
}

void wait() {
  Serial.println("Wait 5 seconds");
  delay(5000);
}
ISR(TIMER2_OVF_vect)
{
    if(airqualitysensor.counter==122)//set 2 seconds as a detected duty
    {
        airqualitysensor.last_vol=airqualitysensor.first_vol;
        airqualitysensor.first_vol=analogRead(A0);
        airqualitysensor.counter=0;
        airqualitysensor.timer_index=1;
        PORTB=PORTB^0x20;
    }
    else
    {
        airqualitysensor.counter++;
    }
}
