import React from 'react';
import { Routes, Route } from 'react-router-dom';
import CafePage from '../pages/CafePage';
import EmployeePage from '../pages/EmployeePage';
import AddEditCafeForm from '../components/cafe/AddEditCafeForm';
import AddEditEmployeeForm from '../components/employee/AddEditEmployeeForm';
import HomePage from '../pages/HomePage';
import AppLayout from '../layout/AppLayout';
import CafeEmployeePage from '../pages/CafeEmployeePage';

const AppRoutes: React.FC = () => {
    return (
        <Routes>
            <Route element={<AppLayout />}>
                <Route path="/" element={<HomePage />} />
                
                <Route path="/cafes" element={<CafePage />} />
                <Route path="/cafes/add" element={<AddEditCafeForm />} />
                <Route path="/cafes/edit/:id" element={<AddEditCafeForm />} />
                <Route path="/cafes/:id/employees" element={<CafeEmployeePage />} />

                <Route path="/employees" element={<EmployeePage />} />
                <Route path="/employees/add" element={<AddEditEmployeeForm />} />
                <Route path="/employees/edit/:id" element={<AddEditEmployeeForm />} />
            </Route>
        </Routes>
    );
};

export default AppRoutes;