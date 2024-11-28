import React, { useEffect, useState } from 'react';
import { Table, Button, Space, message, Modal, Form, Input, Popconfirm } from 'antd';
import { useAppDispatch } from '../../utils/hooks';
import { editCafe, loadCafes, removeCafe } from '../../redux/cafesSlice';
import placeholderImage from '../../assets/placeholder-logo.png';

interface Cafe {
    id: string;
    name: string;
    description: string;
    logo: string | null;
    location: string;
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
        if(!cafes) dispatch(loadCafes());
    }, [dispatch]);

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

    const columns = [
        {
            title: 'Logo',
            dataIndex: 'logo',
            key: 'logo',
            render: () => (<img src={placeholderImage} alt="Logo" style={{ width: 50 }} />),
        },
        { title: 'Name', dataIndex: 'name', key: 'name' },
        { title: 'Description', dataIndex: 'description', key: 'description' },
        { title: 'Location', dataIndex: 'location', key: 'location' },
        {
            title: 'Actions',
            key: 'actions',
            render: (_: any, record: Cafe) => (
                <Space>
                    <Button type="link" onClick={() => handleEdit(record)}>
                        Edit
                    </Button>
                    <Popconfirm
                        title="Are you sure you want to delete this café?"
                        onConfirm={() => handleDelete(record.id)}
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
            <Table dataSource={cafes} columns={columns} rowKey="id" pagination={{ pageSize: 10 }} />

            <Modal
                title="Edit Café"
                open={isModalVisible}
                onCancel={handleCancel}
                onOk={() => form.submit()}
            >
                <Form form={form} layout="vertical" onFinish={handleEditSubmit} onValuesChange={handleValuesChange}>
                    <Form.Item label="Name" name="name" rules={[{ required: true, min: 6, max: 10 }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item label="Description" name="description" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item label="Logo URL" name="logo">
                        <Input />
                    </Form.Item>
                    <Form.Item label="Location" name="location" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                </Form>
            </Modal>
        </React.Fragment>
    );
};

export default CafeTable;