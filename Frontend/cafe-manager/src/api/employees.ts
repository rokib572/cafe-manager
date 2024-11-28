import axios from 'axios';

const API_BASE = 'https://localhost:7154/api/employee';

export const fetchEmployees = async (cafeId?: string) => {
    return axios.get(`${API_BASE}`, { params: { cafeId } });
};

export const createEmployee = async (employeeData: {
    name: string;
    email: string;
    phone: string;
    gender: string;
    cafeId: string;
}) => {
    return axios.post(`${API_BASE}`, employeeData);
};

export const updateEmployee = async (employeeData: {
    id: string;
    name: string;
    emailAddress: string;
    phoneNumber: string;
    gender: string;
    cafeId: string;
}) => {
    return axios.put(`${API_BASE}`, employeeData);
};

export const deleteEmployee = async (id: string) => {
    return axios.delete(`${API_BASE}/${id}`);
};