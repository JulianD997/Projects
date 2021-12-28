
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from datetime import datetime, timedelta, timezone

LABELS_DICT = {
    0:'move_up',
    1:'move_down',
    2:'no_movement'
}

WINDOW_SIZE = 250
WINDOW_OVERLAP = 125

def create_npy(filename:str):
    headers = ['time', 'emg1', 'emg2', 'pos_v']
    dtypes = {
        'time': 'str',
        'emg1': 'float',
        'emg2': 'float',
        'pos_v': 'float'
    }
    parse_dates = ['time']
    df = pd.read_csv(f'./data/{filename}.csv', 
        names=headers, 
        dtype=dtypes)

    df = df.to_numpy(dtype=float)
    np.save(f'./data/{filename}.npy', df)

def auto_label(filename:str, threshold:float=0.1):
    '''
        filename - is the file to load data from, stored in the 
        ./data directory

        threshold - should be postive float - determines the 
        threshold by which gradients will be classified
        by the classes in the LABELS_DICT

    '''
    if (threshold <= 0):
        raise ValueError('threshold must be positive number')

    data = np.load(f'./data/{filename}.npy')
    df = pd.DataFrame({
        'time': data[:,0],
        'emg1': data[:,1],
        'emg2': data[:, 2],
        'pos_v': data[:, 3]
        })
    # smooth the potentiometer data
    df.pos_v = df.pos_v.rolling(center=False, window=WINDOW_OVERLAP).mean()

    # calculate the gradient for automatic labeling
    df['gradient'] = np.gradient(df.pos_v.rolling(center=False, window=WINDOW_OVERLAP).mean())

    # window the data, store in the list called 'windows'
    windows = [df[i:i+WINDOW_SIZE] for i in range(0, df.time.size, WINDOW_OVERLAP)]

    # delete any windows that do not match the specified size
    for i in range(len(windows)-1, 0, -1):
        if len(windows[i]) != WINDOW_SIZE:
            del windows[i]

    # based on the average gradients of each window and the threshold, label automatically
    labels = []
    avg_grads = []
    for window in windows:
        avg_grad = window.gradient.sum()/window.gradient.size
        avg_grads.append(avg_grad)
        if avg_grad > threshold:
            labels.append(0)
        elif avg_grad < -1*threshold:
            labels.append(1)
        else:
            labels.append(2)
    print(f'up: {labels.count(0)}')
    print(f'down: {labels.count(1)}')
    print(f'no change: {labels.count(2)}')

    return windows, labels

def load_data(filename:str, label:int):
    '''
        filename - is the file to load data from

        label - what to label windows from this file as an int
            0:'move_up',
            1:'move_down',
            2:'no_movement'
    '''
    # load the data
    data = np.load(f'{filename}')
    print(data.shape)

    # label the columns
    df = pd.DataFrame({
        'time': data[:,0],
        'emg1': data[:,1],
        'emg2': data[:, 2],
        'pos_v': data[:, 3]
        })
    
    # smooth the potentiometer data
    # df.pos_v = df.pos_v.rolling(center=False, window=WINDOW_OVERLAP).mean()

    # window the data, store in the list called 'windows'
    windows = [df[i:i+WINDOW_SIZE] for i in range(0, df.time.size, WINDOW_OVERLAP)]

    # delete any windows that do not match the specified size
    for i in range(len(windows)-1, 0, -1):
        if len(windows[i]) != WINDOW_SIZE:
            del windows[i]

    # create a list of labels which has a label for each window
    labels = [label for window in windows]

    if len(windows) != len(labels):
        raise ValueError('number of windows and labels must be equivalent')

    return windows, labels
    

def plot_windows(windows:pd.DataFrame, labels:list):
    for i in range(0, len(windows)):
        window = windows[i]
        window.to_csv(f'./labeled_data/{LABELS_DICT[labels[i]]}/{i}.csv')
        print(f'{i}')
        ax = plt.gca()
        # window.plot(kind='line', x='time', y='emg1', ax=ax)
        # window.plot(kind='line', x='time', y='emg2', ax=ax)
        window.plot(kind='line', x='time', y='pos_v', ax=ax)
        plt.title(f'{labels_dict[labels[i]]}')
        plt.ylim(900,1900)
        plt.savefig(f'./pics/{i}.png')
        plt.clf()

def print_window_data(windows:list, window:int, labels:list):
    print(f'window: {windows[window]}')
    print(f'label: {LABELS_DICT[labels[window]]}')
    print(f'average gradient: {windows[window].gradient.mean()} ')

def window_df_to_array(window:pd.DataFrame):
    window_emg1_data = window.emg1.to_numpy()
    window_emg2_data = window.emg2.to_numpy()

    return np.append(window_emg1_data, window_emg2_data)

def train_model(windows:list, labels:list):
    import tensorflow as tf
    from sklearn.model_selection import train_test_split

    if len(windows) != len(labels):
        raise ValueError('number of windows and labels must be equivalent')
    emg_data = np.array([window_df_to_array(window) for window in windows])

    print(f'shape of the data before train/test split: {emg_data.shape}')

    x_train, x_test, y_train, y_test = train_test_split(
        emg_data, labels, test_size=0.1)

    model = tf.keras.models.Sequential([
        tf.keras.layers.Flatten(input_shape=(WINDOW_SIZE*2,)),
        tf.keras.layers.Dense(256, activation='relu'),
        tf.keras.layers.Dense(256, activation='relu'),
        tf.keras.layers.Dense(256, activation='relu'),
        tf.keras.layers.Dropout(0.2),
        tf.keras.layers.Dense(3, activation='softmax')
    ])

    model.compile(optimizer='adam',
        loss='sparse_categorical_crossentropy',
        metrics=['accuracy'])

    print('training model...')
    model.fit(x_train, y_train, epochs=10)

    print('evaluating model...')
    model.evaluate(x_test, y_test)


if __name__ == "__main__":
    mu_windows, mu_labels = load_data('./data/datasets/move_up.npy', 0)
    md_windows, md_labels = load_data('./data/datasets/move_down.npy', 1)
    nm_windows, nm_labels = load_data('./data/datasets/no_movement.npy', 2)

    windows = mu_windows + md_windows + nm_windows
    labels = np.asarray(mu_labels + md_labels + nm_labels)

    train_model(windows, labels)
    
    print('done')