
import json
import matplotlib.pyplot as plt

with open('data.json', 'r') as f:
    data = f.read()

plt.plot(json.loads(data))
plt.ylabel('some numbers')
plt.savefig('mygraph.png')