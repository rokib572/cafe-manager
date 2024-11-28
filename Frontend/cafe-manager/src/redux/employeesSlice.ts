import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchEmployees, updateEmployee, deleteEmployee } from '../api/employees';

interface Employee {
    id: string;
    name: string;
    emailAddress: string;
    phoneNumber: string;
    gender: string;
    cafe: string;
    cafeId: string;
}

interface EmployeesState {
    data: Employee[];
    loading: boolean;
    error: string | null;
}

const initialState: EmployeesState = {
    data: [],
    loading: false,
    error: null,
};

export const loadEmployees = createAsyncThunk<Employee[]>('employees/load', async () => {
    const response = await fetchEmployees();
    return response.data;
});

export const editEmployee = createAsyncThunk<Employee, Employee>(
    'employees/edit',
    async (employeeData) => {
        const response = await updateEmployee(employeeData);
        return response.data;
    }
);

export const removeEmployee = createAsyncThunk<string, string>(
    'employees/remove',
    async (id) => {
        await deleteEmployee(id);
        return id;
    }
);

const employeesSlice = createSlice({
    name: 'employees',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(loadEmployees.fulfilled, (state, action) => {
                state.data = action.payload;
                state.loading = false;
            })
            .addCase(editEmployee.fulfilled, (state, action) => {
                const index = state.data.findIndex((e) => e.id === action.payload.id);
                if (index !== -1) {
                    state.data[index] = action.payload;
                }
            })
            .addCase(removeEmployee.fulfilled, (state, action) => {
                state.data = state.data.filter((e) => e.id !== action.payload);
            });
    },
});

export default employeesSlice.reducer;