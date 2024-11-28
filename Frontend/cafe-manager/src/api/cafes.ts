import axios from 'axios';

const API_BASE = 'https://localhost:7154/api/cafe';

export const fetchCafes = async (location?: string) => {
    const params = location ? { location } : undefined;
    return axios.get(`${API_BASE}`, { params });
};

export const createCafe = async (cafeData: {
    name: string;
    description: string;
    logo: string | null;
    location: string;
}) => {
    return axios.post(`${API_BASE}`, cafeData);
};

export const updateCafe = async (cafeData: {
    id: string;
    name: string;
    description: string;
    logo: string | null;
    location: string;
}) => {
    return axios.put(`${API_BASE}`, cafeData);
};

export const deleteCafe = async (id: string) => {
    return axios.delete(`${API_BASE}/${id}`);
};

export const getEmployeesByCafe = async (cafeId: string) => {
    const response = await axios.get(`${API_BASE}/${cafeId}`);
    return response.data;
};