import { useEffect, useState, useCallback } from 'react';
import { useParams } from 'react-router-dom';
import { getEmployeesByCafe } from '../api/cafes';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import { ColDef } from 'ag-grid-community';

interface Employee {
    id: string;
    name: string;
    emailAddress: string;
    phoneNumber: string;
    daysWorked: number;
    cafe: string;
}

const CafeEmployeePage = () => {
    const { id } = useParams<{ id: string }>();
    const [employees, setEmployees] = useState<Employee[]>([]);
    const [cafeName, setCafeName] = useState<string>('');

    const fetchEmployees = useCallback(async () => {
        try {
            if (id) {
                const data: Employee[] = await getEmployeesByCafe(id);
                setEmployees(data);
                if (data.length > 0) {
                    setCafeName(data[0].cafe);
                } else {
                    setCafeName('No Employees Found');
                }
            }
        } catch (error) {
            console.error('Error fetching employees:', error);
        }
    }, [id]);

    useEffect(() => {
        fetchEmployees();
    }, [fetchEmployees]);

    const columnDefs: ColDef<Employee>[] = [
        { headerName: 'Employee ID', field: 'id', flex: 1 },
        { headerName: 'Name', field: 'name', flex: 1 },
        { headerName: 'Email', field: 'emailAddress', flex: 1 },
        { headerName: 'Phone', field: 'phoneNumber', flex: 1 },
        { headerName: 'Days Worked', field: 'daysWorked', flex: 1 },
    ];

    return (
        <div>
            <h1>Employees for Cafe: <strong>{cafeName || 'Loading...'}</strong></h1>
            <div className="ag-theme-alpine" style={{ height: 400, width: '100%' }}>
                <AgGridReact
                    rowData={employees}
                    columnDefs={columnDefs}
                    domLayout="autoHeight"
                    pagination={true}
                    paginationPageSize={10}
                />
            </div>
        </div>
    );
};

export default CafeEmployeePage;