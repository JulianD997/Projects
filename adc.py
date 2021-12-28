# the purpose of this file is to interface the mcp3208 and collect emg sensor data
# stored in ./data/

# data format = {time, emg1, emg2, potentiometer}

from mcp3208 import MCP3208
from datetime import datetime
adc = MCP3208()

with open(f"./data/no_movement/nate_{datetime.now()}.dat", 'w') as file:
    while True:
        timestamp = datetime.now().timestamp()
        data = f'{timestamp}, {adc.read(6)}, {adc.read(7)}, {adc.read(5) - adc.read(4)} \n'
        print(data)
        file.write(data)
        
