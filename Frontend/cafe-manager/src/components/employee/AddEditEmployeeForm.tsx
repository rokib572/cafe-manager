import React, { useEffect, useState } from 'react';
import { Form, Input, Button, Select, message, Radio } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import { createEmployee, updateEmployee } from '../../api/employees';
import { fetchCafes } from '../../api/cafes';

const { Option } = Select;

const AddEditEmployeeForm: React.FC = () => {
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const [form] = Form.useForm();

  const [cafes, setCafes] = useState<{ id: string; name: string }[]>([]);

  useEffect(() => {
    const loadCafes = async () => {
      try {
        const response = await fetchCafes();
        setCafes(response.data);
      } catch (error) {
        message.error('Failed to fetch cafes');
      }
    };
    loadCafes();
  }, []);

  const handleSubmit = async (values: any) => {
    try {
      if (id) {
        await updateEmployee({ id, ...values });
        message.success('Employee updated successfully!');
      } else {
        await createEmployee(values);
        message.success('Employee created successfully!');
      }
      navigate('/employees');
    } catch (error) {
      message.error('Failed to save employee');
    }
  };

  return (
    <div>
      <h1>{id ? 'Edit Employee' : 'Add Employee'}</h1>
      <Form
        form={form}
        layout="vertical"
        onFinish={handleSubmit}
        initialValues={{
          name: '',
          emailAddress: '',
          phoneNumber: '',
          gender: '',
          cafeId: '',
        }}
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
          label="Email"
          name="emailAddress"
          rules={[
            { required: true, message: 'Please enter an email' },
            { type: 'email', message: 'Please enter a valid email' },
          ]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          label="Phone"
          name="phoneNumber"
          rules={[
            { required: true, message: 'Please enter a phone number' },
            { pattern: /^[89]\d{7}$/, message: 'Phone must start with 8 or 9 and be 8 digits long' },
          ]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          label="Gender"
          name="gender"
          rules={[{ required: true, message: 'Please select a gender' }]}
        >
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
          <Select placeholder="Select a café">
            {cafes.map((cafe) => (
              <Option key={cafe.id} value={cafe.id}>
                {cafe.name}
              </Option>
            ))}
          </Select>
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit">
            Submit
          </Button>
          <Button style={{ marginLeft: '10px' }} onClick={() => navigate('/employees')}>
            Cancel
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};

export default AddEditEmployeeForm;