%global a;
interval = 200;
a = arduino('COM14','Nano3');
%configurePin(a,'A0','AnalogInput');
i=1;
x=0;
while(i < interval)
    b=readVoltage(a,'A0');
    x=[x,b];
    plot(x);
    grid ON;
    interval=interval+1;
    drawnow;
end
