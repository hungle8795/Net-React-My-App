import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { User } from '../../types/auth';
import axiosInstance from '../../common/axiosInstance';

export const fetchUsers = createAsyncThunk('fetchUsers', async () => {
  // eslint-disable-next-line no-useless-catch
  try {
    const response = await axiosInstance.get('/Accounts');
    return response.data;
  } catch (error) {
    throw error;
  }
});

const initialState: User[] = [];

export const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchUsers.pending, (state) => {
        console.log('Fetching users loading');
        console.log(state);
      })
      .addCase(fetchUsers.fulfilled, (state, action) => {
        console.log('Fetching users success');
        console.log(state);
        return action.payload;
      })
      .addCase(fetchUsers.rejected, (state) => {
        console.log(state);
        console.log('Fetching users error');
        return [];
      });
  },
});

export const userReducer = userSlice.reducer;
export default userReducer;
