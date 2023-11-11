import { configureStore } from  "@reduxjs/toolkit";
import { readerSlice } from  "./readerSlice";
import { readerTrackingSlice } from  "./readerTrackingSlice";
import { createWrapper,  } from  "next-redux-wrapper";

const makeStore = () =>
  configureStore({
    reducer: {
      [readerSlice.name]: readerSlice.reducer,
      [readerTrackingSlice.name]: readerTrackingSlice.reducer,
    },
    devTools: true,
  });

  export type AppStore = ReturnType<typeof makeStore>;
  export type AppState = ReturnType<AppStore["getState"]>;
  export const wrapper = createWrapper<AppStore>(makeStore);