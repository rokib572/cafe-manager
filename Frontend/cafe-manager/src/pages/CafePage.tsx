import React, { useState, useEffect } from 'react';
import { Button, Input, Space } from 'antd';
import { useAppDispatch, useAppSelector } from '../utils/hooks';
import { loadCafes } from '../redux/cafesSlice';
import CafeTable from '../components/cafe/CafeTable';
import { useNavigate } from 'react-router-dom';

const CafePage: React.FC = () => {
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const cafes = useAppSelector((state) => state.cafes.data);
    const [filteredCafes, setFilteredCafes] = useState(cafes);
    const [searchText, setSearchText] = useState<string>('');

    useEffect(() => {
        dispatch(loadCafes());
    }, [dispatch]);

    useEffect(() => {
        const query = searchText.toLowerCase();
        const filtered = cafes.filter(
            (cafe) =>
                cafe.name.toLowerCase().includes(query) ||
                cafe.location.toLowerCase().includes(query) ||
                cafe.description.toLowerCase().includes(query)
        );
        setFilteredCafes(filtered);
    }, [searchText, cafes]);

    const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearchText(e.target.value);
    };

    return (
        <div>
            <h1>Cafés</h1>
            <Space style={{ margin: '20px' }}>
                <Button type="primary" onClick={() => navigate('/cafes/add')}>
                    Add New Café
                </Button>
                <Input
                    placeholder="Search by name, location, or description"
                    value={searchText}
                    onChange={handleSearch}
                    style={{ width: '300px' }}
                />
            </Space>
            <CafeTable cafes={filteredCafes} />
        </div>
    );
};

export default CafePage;