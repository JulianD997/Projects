
import numpy as np
import pandas as pd
from datetime import datetime, timedelta, timezone

headers = ['time', 'emg1', 'emg2', 'pos_v']
dtypes = {
    'time': 'str',
    'emg1': 'float',
    'emg2': 'float',
    'pos_v': 'float'
}
parse_dates = ['time']
df = pd.read_csv('./data/normal.csv', 
    names=headers, 
    dtype=dtypes)

timelist = list(df['time'].values)

timelist = [datetime.strptime(time,'%M:%S:%f').replace().timestamp() for time in timelist]
init = timelist[0]
timelist = [time - init for time in timelist]
df = df.assign(time=timelist)

df = df.to_numpy(dtype=float)
np.save('./data/normal.npy', df)
print(df)
print('done')