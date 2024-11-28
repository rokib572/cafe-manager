import React, { useEffect, useState } from 'react';
import { Button, Space, message, Modal, Form, Input, Popconfirm } from 'antd';
import { useAppDispatch } from '../../utils/hooks';
import { editCafe, loadCafes, removeCafe } from '../../redux/cafesSlice';
import placeholderImage from '../../assets/placeholder-logo.png';
import { AgGridReact } from 'ag-grid-react';
import { ColDef } from 'ag-grid-community';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';

interface Cafe {
    id: string;
    name: string;
    description: string;
    logo: string | null;
    location: string;
    employees?: number;
}

interface CafeTableProps {
    cafes: Cafe[];
}

const CafeTable: React.FC<CafeTableProps> = ({ cafes }) => {
    const dispatch = useAppDispatch();

    const [isModalVisible, setIsModalVisible] = React.useState(false);
    const [editingCafe, setEditingCafe] = React.useState<Cafe | null>(null);
    const [form] = Form.useForm();
    const [isDirty, setIsDirty] = useState(false);

    useEffect(() => {
        if (!cafes) dispatch(loadCafes());
    }, [dispatch, cafes]);

    const handleEdit = (cafe: Cafe) => {
        setEditingCafe(cafe);
        form.setFieldsValue(cafe);
        setIsModalVisible(true);
    };

    const handleEditSubmit = async (values: any) => {
        try {
            if (editingCafe) {
                await dispatch(editCafe({ ...editingCafe, ...values }));
                message.success('Café updated successfully');
                setIsDirty(false);
                setIsModalVisible(false);
                setEditingCafe(null);
                dispatch(loadCafes());
            }
        } catch {
            message.error('Failed to update café');
        }
    };

    const handleDelete = async (id: string) => {
        try {
            await dispatch(removeCafe(id));
            message.success('Café deleted successfully');
        } catch {
            message.error('Failed to delete café');
        }
    };

    const handleValuesChange = () => {
        setIsDirty(true);
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

    const columnDefs: ColDef<Cafe>[] = [
        {
            headerName: 'Logo',
            field: 'logo',
            cellRenderer: () => (
                <img
                    src={placeholderImage}
                    alt="Logo"
                    style={{ width: 20 }}
                />
            ),
        },
        { headerName: 'Name', field: 'name', sortable: true, filter: true, flex: 1 },
        { headerName: 'Description', field: 'description', flex: 2 },
        { headerName: 'Location', field: 'location', sortable: true, filter: true, flex: 1 },
        {
            headerName: 'Employees',
            field: 'employees',
            cellRenderer: (params: any) => (
                <a href={`/cafes/${params.data.id}/employees`}>{params.value}</a>
            ),
            flex: 1,
        },
        {
            headerName: 'Actions',
            cellRenderer: (params: any) => (
                <Space>
                    <Button type="link" onClick={() => handleEdit(params.data)}>
                        Edit
                    </Button>
                    <Popconfirm
                        title="Are you sure you want to delete this café?"
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
                <AgGridReact<Cafe>
                    rowData={cafes}
                    columnDefs={columnDefs}
                    domLayout="autoHeight"
                    pagination={true}
                    paginationPageSize={10}
                />
            </div>

            <Modal
                title="Edit Café"
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
                        rules={[
                            { required: true, message: 'Name is required' },
                            { min: 6, max: 10, message: 'Name must be 6-10 characters' },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Description"
                        name="description"
                        rules={[{ required: true, message: 'Description is required' }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item label="Logo URL" name="logo">
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Location"
                        name="location"
                        rules={[{ required: true, message: 'Location is required' }]}
                    >
                        <Input />
                    </Form.Item>
                </Form>
            </Modal>
        </React.Fragment>
    );
};

export default CafeTable;