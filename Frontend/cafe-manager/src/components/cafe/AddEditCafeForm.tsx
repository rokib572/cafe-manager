import React, { useEffect, useState } from 'react';
import { Form, Input, Button, message } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import { createCafe, updateCafe } from '../../api/cafes';

const AddEditCafeForm: React.FC = () => {
    const navigate = useNavigate();
    const { id } = useParams<{ id: string }>();
    const [form] = Form.useForm();
    const [isDirty, setIsDirty] = useState(false);

    useEffect(() => {
        const handleBeforeUnload = (e: BeforeUnloadEvent) => {
            if (isDirty) {
                e.preventDefault();
                e.returnValue = '';
            }
        };

        window.addEventListener('beforeunload', handleBeforeUnload);
        return () => window.removeEventListener('beforeunload', handleBeforeUnload);
    }, [isDirty]);
        
    const handleSubmit = async (values: any) => {
        try {
            if (id) {
                await updateCafe({ id, ...values });
                message.success('Café updated successfully!');
            } else {
                await createCafe(values);
                message.success('Café created successfully!');
            }
            setIsDirty(false);
            navigate('/cafes');
        } catch (error) {
            message.error('An error occurred.');
        }
    };

    const handleValuesChange = () => {
        setIsDirty(true);
    };

    return (
        <div>
            <h1>{id ? 'Edit Café' : 'Add Café'}</h1>
            <Form
                form={form}
                layout="vertical"
                onFinish={handleSubmit}
                initialValues={{ name: '', description: '', location: '' }}
                onValuesChange={handleValuesChange}
            >
                <Form.Item
                    label="Name"
                    name="name"
                    rules={[
                        { required: true, message: 'Please enter a name' },
                        { min: 6, max: 10, message: 'Name must be 6-10 characters' },
                    ]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    label="Description"
                    name="description"
                    rules={[
                        { required: true, message: 'Please enter a description' },
                        { max: 256, message: 'Description must be up to 256 characters' },
                    ]}
                >
                    <Input.TextArea />
                </Form.Item>
                <Form.Item label="Location" name="location" rules={[{ required: true, message: 'Please enter a location' }]}>
                    <Input />
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit">
                        Submit
                    </Button>
                    <Button style={{ marginLeft: '10px' }} onClick={() => navigate('/cafes')}>
                        Cancel
                    </Button>
                </Form.Item>
            </Form>
        </div>
    );
};

export default AddEditCafeForm;