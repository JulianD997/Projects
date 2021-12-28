 
import numpy as np
import pandas as pd
from datetime import datetime, timedelta, timezone

def create_npy(filename:str, dataset:np.array):
    data = np.load(f'./data/{filename}.npy')
    # df = pd.DataFrame({
    # 'time': data[:,0],
    # 'emg1': data[:,1],
    # 'emg2': data[:, 2],
    # 'pos_v': data[:, 3]
    # })

    # base = df.time[0]
    # df.time = df.time - base
    # np.save(f'./data/{filename}.npy', df)
    print(data.shape)
    print(dataset.shape)
    return np.concatenate((dataset, data))

if __name__ == "__main__":
    # move down
    dataset_1 = np.load(f'./data/move_down/julian_1.npy')
    for i in range(2, 20):
        dataset_1 = create_npy(f'move_down/julian_{i}', dataset_1)
    for i in range(1, 16):
        dataset_1 = create_npy(f'move_down/nate_{i}', dataset_1)
    for i in range(1, 18):
        dataset_1 = create_npy(f'move_down/nick_{i}', dataset_1)
    for i in range(1, 21):
        dataset_1 = create_npy(f'move_down/noah_{i}', dataset_1)
    
    # save movedown dataset
    np.save(f'./data/datasets/move_down.npy', dataset_1)

    # move up
    dataset_2 = np.load(f'./data/move_up/julian_1.npy')
    for i in range(2, 16):
        dataset_2 = create_npy(f'move_up/julian_{i}', dataset_2)
    for i in range(1, 16):
        dataset_2 = create_npy(f'move_up/nate_{i}', dataset_2)
    for i in range(1, 5):
        dataset_2 = create_npy(f'move_up/nick_{i}', dataset_2)
    for i in range(1, 21):
        dataset_2 = create_npy(f'move_up/noah_{i}', dataset_2)
    
    # save move up dataset
    np.save(f'./data/datasets/move_up.npy', dataset_2)

    # no movement
    dataset_3 = np.load(f'./data/no_movement/julian_1.npy')
    for i in range(1, 3):
        dataset_3 = create_npy(f'no_movement/julian_{i}', dataset_3)
    for i in range(1, 14):
        dataset_3 = create_npy(f'no_movement/nate_{i}', dataset_3)
    for i in range(1, 7):
        dataset_3 = create_npy(f'no_movement/nick_{i}', dataset_3)
    for i in range(1, 11):
        dataset_3 = create_npy(f'no_movement/noah_{i}', dataset_3)

    # save no movement dataset
    np.save(f'./data/datasets/no_movement.npy', dataset_3)
