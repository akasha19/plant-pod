#include <ArduinoJson.h>
#include <Ethernet.h>
#include <SPI.h>
#include "DHT.h"

// Defines the temparature/humidity sensor
#define DHTPIN 2     
#define DHTTYPE DHT11  
DHT dht(DHTPIN, DHTTYPE); 

EthernetClient client;
byte mac[] = {0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED};
const char* server = "192.168.68.144";
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
  delay(1000);
}

// endless loop
void loop() {

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
     Serial.println(temp);
     
  StaticJsonBuffer<200> jsonBuffer;
  JsonObject& root = jsonBuffer.createObject();
  root["sensorId"] = "196db225-e5ef-4636-b967-c214a0ddb73f";
  root["temperature"] = temp;
  
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
