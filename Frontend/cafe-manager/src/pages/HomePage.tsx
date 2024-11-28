import React from 'react';
import { Button, Typography, Row, Col } from 'antd';
import { useNavigate } from 'react-router-dom';

const { Title, Paragraph } = Typography;

const HomePage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div style={{ padding: '50px', textAlign: 'center', background: '#f9f9f9', minHeight: '100vh' }}>
      <Row justify="center" style={{ marginBottom: '30px' }}>
        <Col>
          <Title level={1} style={{ fontWeight: 'bold', color: '#2c3e50' }}>
            Welcome to Café Management
          </Title>
          <Paragraph style={{ fontSize: '18px', color: '#7f8c8d' }}>
            You can see Cafés and Employees from here.
          </Paragraph>
        </Col>
      </Row>

      <Row justify="center">
        <Col>
          <Button
            type="primary"
            size="large"
            style={{ padding: '10px 40px', fontSize: '16px' }}
            onClick={() => navigate('/cafes')}
          >
            Explore Cafés
          </Button>
        </Col>
        <Col>
          <Button
            type="primary"
            size="large"
            style={{ padding: '10px 40px', fontSize: '16px', marginLeft: '40px' }}
            onClick={() => navigate('/employees')}
          >
            Explore Employees
          </Button>
        </Col>
      </Row>
    </div>
  );
};

export default HomePage;