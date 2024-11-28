import { configureStore } from '@reduxjs/toolkit';
import cafesReducer from './cafesSlice';
import employeesReducer from './employeesSlice';

const store = configureStore({
  reducer: {
    cafes: cafesReducer,
    employees: employeesReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;