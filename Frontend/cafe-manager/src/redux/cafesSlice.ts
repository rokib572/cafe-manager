import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchCafes, updateCafe, deleteCafe } from '../api/cafes';

interface Cafe {
    id: string;
    name: string;
    description: string;
    logo: string | null;
    location: string;
}

interface CafesState {
    data: Cafe[];
    loading: boolean;
    error: string | null;
}

const initialState: CafesState = {
    data: [],
    loading: false,
    error: null,
};

export const loadCafes = createAsyncThunk<Cafe[], string | undefined>(
    'cafes/load',
    async (location) => {
        const response = await fetchCafes(location);
        return response.data;
    }
);

export const editCafe = createAsyncThunk<Cafe, Cafe>(
    'cafes/edit',
    async (cafeData) => {
        const response = await updateCafe(cafeData);
        return response.data;
    }
);

export const removeCafe = createAsyncThunk<string, string>(
    'cafes/delete',
    async (id) => {
        await deleteCafe(id);
        return id;
    }
);

const cafesSlice = createSlice({
    name: 'cafes',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(loadCafes.pending, (state) => {
                state.loading = true;
            })
            .addCase(loadCafes.fulfilled, (state, action) => {
                state.data = action.payload;
                state.loading = false;
            })
            .addCase(editCafe.fulfilled, (state, action) => {
                const index = state.data.findIndex((cafe) => cafe.id === action.payload.id);
                if (index !== -1) {
                    state.data[index] = action.payload;
                }
            })
            .addCase(removeCafe.fulfilled, (state, action) => {
                state.data = state.data.filter((cafe) => cafe.id !== action.payload);
            });
    },
});

export default cafesSlice.reducer;