import React, { useState, useEffect } from 'react';
import { Button, Space, message, Modal, Form, Input, Radio, Select, Popconfirm } from 'antd';
import { useAppDispatch } from '../../utils/hooks';
import { removeEmployee, editEmployee, loadEmployees } from '../../redux/employeesSlice';
import { fetchCafes } from '../../api/cafes';
import { AgGridReact } from 'ag-grid-react';
import { ColDef } from 'ag-grid-community';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';

const { Option } = Select;

interface Employee {
    id: string;
    name: string;
    emailAddress: string;
    phoneNumber: string;
    gender: string;
    cafeId: string;
    cafe: string;
    daysWorked: number;
}

const EmployeeTable = ({ employees }: { employees: Employee[] }) => {
    const dispatch = useAppDispatch();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [editingEmployee, setEditingEmployee] = useState<Employee | null>(null);
    const [cafes, setCafes] = useState<{ id: string; name: string }[]>([]);
    const [isDirty, setIsDirty] = useState(false);

    const [form] = Form.useForm();

    useEffect(() => {
        dispatch(loadEmployees());

        const loadCafes = async () => {
            try {
                const response = await fetchCafes();
                setCafes(response.data);
            } catch {
                message.error('Failed to fetch cafés');
            }
        };
        loadCafes();
    }, [dispatch]);

    const handleDelete = async (id: string) => {
        try {
            await dispatch(removeEmployee(id));
            message.success('Employee deleted successfully');
        } catch {
            message.error('Failed to delete employee');
        }
    };

    const handleEdit = (employee: Employee) => {
        setEditingEmployee(employee);
        form.setFieldsValue(employee);
        setIsModalVisible(true);
    };

    const handleEditSubmit = async (values: any) => {
        try {
            if (editingEmployee) {
                await dispatch(editEmployee({ ...editingEmployee, ...values }));
                message.success('Employee updated successfully');
                setIsDirty(false);
                setIsModalVisible(false);
                setEditingEmployee(null);
                dispatch(loadEmployees());
            }
        } catch {
            message.error('Failed to update employee');
        }
    };

    const handleCancel = () => {
        if (isDirty) {
            Modal.confirm({
                title: 'Unsaved Changes',
                content: 'You have unsaved changes. Are you sure you want to close?',
                okText: 'Yes',
                cancelText: 'No',
                onOk: () => {
                    setIsDirty(false);
                    setIsModalVisible(false);
                },
            });
        } else {
            setIsModalVisible(false);
        }
    };

    const handleValuesChange = () => {
        setIsDirty(true);
    };

    const columnDefs: ColDef<Employee>[] = [
        { headerName: 'Employee ID', field: 'id', sortable: true, filter: true },
        { headerName: 'Name', field: 'name', sortable: true, filter: true, flex: 1 },
        { headerName: 'Email', field: 'emailAddress', sortable: true, filter: true, flex: 1 },
        { headerName: 'Phone', field: 'phoneNumber', flex: 1 },
        { headerName: 'Days Worked', field: 'daysWorked', flex: 1 },
        { headerName: 'Café Name', field: 'cafe', flex: 1 },
        {
            headerName: 'Actions',
            cellRenderer: (params: any) => (
                <Space>
                    <Button type="link" onClick={() => handleEdit(params.data)}>
                        Edit
                    </Button>
                    <Popconfirm
                        title="Are you sure you want to delete this employee?"
                        onConfirm={() => handleDelete(params.data.id)}
                        okText="Yes"
                        cancelText="No"
                    >
                        <Button type="link" danger>
                            Delete
                        </Button>
                    </Popconfirm>
                </Space>
            ),
        },
    ];

    return (
        <React.Fragment>
            <div className="ag-theme-alpine" style={{ height: 500, width: '100%' }}>
                <AgGridReact<Employee>
                    rowData={employees}
                    columnDefs={columnDefs}
                    domLayout="autoHeight"
                    pagination={true}
                    paginationPageSize={10}
                    getRowId={(params) => params.data.id} // Use Employee ID as a unique identifier
                />
            </div>

            <Modal
                title="Edit Employee"
                open={isModalVisible}
                onCancel={handleCancel}
                onOk={() => form.submit()}
            >
                <Form
                    form={form}
                    layout="vertical"
                    onFinish={handleEditSubmit}
                    onValuesChange={handleValuesChange}
                >
                    <Form.Item
                        label="Name"
                        name="name"
                        rules={[{ required: true, min: 6, max: 10 }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Email"
                        name="emailAddress"
                        rules={[{ required: true, type: 'email' }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Phone"
                        name="phoneNumber"
                        rules={[
                            {
                                required: true,
                                pattern: /^[89]\d{7}$/,
                                message: 'Invalid phone number',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item label="Gender" name="gender" rules={[{ required: true }]}>
                        <Radio.Group>
                            <Radio value="Male">Male</Radio>
                            <Radio value="Female">Female</Radio>
                        </Radio.Group>
                    </Form.Item>
                    <Form.Item
                        label="Assigned Café"
                        name="cafeId"
                        rules={[{ required: true, message: 'Please select a café' }]}
                    >
                        <Select>
                            {cafes.map((cafe) => (
                                <Option key={cafe.id} value={cafe.id}>
                                    {cafe.name}
                                </Option>
                            ))}
                        </Select>
                    </Form.Item>
                </Form>
            </Modal>
        </React.Fragment>
    );
};

export default EmployeeTable;