import React from 'react';
import { Button, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { loadEmployees } from '../redux/employeesSlice';
import EmployeeTable from '../components/employee/EmployeeTable';
import { useAppDispatch } from '../utils/hooks';

const EmployeePage: React.FC = () => {
    const navigate = useNavigate();
    const dispatch = useAppDispatch();
    const employees = useSelector((state: any) => state.employees.data);

    React.useEffect(() => {
        dispatch(loadEmployees());
    }, [dispatch]);

    return (
        <div>
            <h1>Employees</h1>
            <Space style={{ marginBottom: '20px' }}>
                <Button type="primary" onClick={() => navigate('/employees/add')}>
                    Add New Employee
                </Button>
            </Space>
            <EmployeeTable employees={employees} />
        </div>
    );
};

export default EmployeePage;