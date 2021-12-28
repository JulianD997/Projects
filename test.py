# the purpose of this file is to interface the mcp3208 and collect emg sensor data
# stored in emg_data.dat

from mcp3208 import MCP3208
import datetime as dt
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import time

adc = MCP3208()

fig = plt.figure()
ax = fig.add_subplot(1, 1, 1)
xs = []
ys = []
ys2 = []
ys3 = []
# This function is called periodically from FuncAnimation
def animate(i, xs, ys, ys2, ys3):

    adc = MCP3208()
    
    # Add x and y to lists
    xs.append(dt.datetime.now().strftime('%H:%M:%S.%f'))
    ys.append(adc.read(6))
    #y1 = adc.read(7)
    #y2 = adc.read(6)
    ys2.append(adc.read(7))
    ys3.append(adc.read(5) - adc.read(4))
    # Draw x and y lists
    ax.clear()
    ax.plot(xs, ys,  label='emg1')
    ax.plot(xs, ys2, label='emg2')
    ax.plot(xs, ys3, label='pos_v')
    ax.legend()
    if i > 25:
        del xs[0]
        del ys[0]
        del ys2[0]
        del ys3[0]
ani = animation.FuncAnimation(fig, animate, fargs=(xs, ys, ys2, ys3), interval=1)
plt.show()
