import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AppState } from "./store";

export interface SessionState {
  token: string | null;
}

const initialState: SessionState = {
  token: null,
};

export const sessionSlice = createSlice({
  name: 'session',
  initialState,
  reducers: {
    settoken: (state, action: PayloadAction<string>) => {
      state.token = action.payload;
    },
  },
});

export const { settoken } = sessionSlice.actions;

export const token = (state: AppState) => state.session.token;

export default sessionSlice.reducer;