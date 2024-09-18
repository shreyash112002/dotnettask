import React, { useState, useEffect } from 'react';
import { fetchUsers } from '../services/userService';
import UserCard from './UserCard';

const UserList = () => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const getUsers = async () => {
            try {
                const fetchedUsers = await fetchUsers();
                setUsers(fetchedUsers);
                console.log(users)
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        };

        getUsers();
    }, []);

    return (
        <div className="container mt-4">
            <h2>Users List</h2>
            <div className="row">
                {users.map(user => (
                    <UserCard key={user.id} user={user} />
                ))}
            </div>
        </div>
    );
};

export default UserList;