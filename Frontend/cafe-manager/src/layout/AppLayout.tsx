import React, { useState } from 'react';
import { Layout, Menu } from 'antd';
import { Outlet, useNavigate } from 'react-router-dom';

const { Header, Content, Footer } = Layout;

const AppLayout: React.FC = () => {
    const navigate = useNavigate();
    const [currentMenu, setCurrentMenu] = useState<string>('home');
    const menuItems = [
        {
            label: 'Home',
            key: 'home',
            onClick: () => navigate('/'),
            style: { width: '25%' },
        },
        {
            label: 'Cafés',
            key: 'cafes',
            onClick: () => navigate('/cafes'),
            style: { width: '25%' },
        },
        {
            label: 'Employees',
            key: 'employees',
            onClick: () => navigate('/employees'),
            style: { width: '25%' },
        },
    ];

    return (
        <Layout className="app-layout">
            <Header className="app-header">
                <Menu
                    theme="light"
                    mode="horizontal"
                    selectedKeys={[currentMenu]}
                    items={menuItems}
                    onClick={(e) => setCurrentMenu(e.key)}
                    className="app-menu"
                />
            </Header>
            <Content className="app-content">
                <Outlet />
            </Content>
            <Footer className="app-footer">
                Café Management ©2024 Created by Rokib Hassan
            </Footer>
        </Layout>
    );
};

export default AppLayout;