import React from 'react';
import { Layout } from 'antd';
import AppRoutes from './routes/AppRoutes';
import './styles/custom.css';

const { Content } = Layout;

const App: React.FC = () => {
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Content style={{ padding: '20px', background: '#f0f2f5' }}>
        <AppRoutes />
      </Content>
    </Layout>
  );
};

export default App;