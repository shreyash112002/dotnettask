import React, { useState } from 'react';
import { deleteUserById } from '../services/userService';

const DeleteUser = () => {
    const [userId, setUserId] = useState('');

    const handleDelete = async (e) => {
        e.preventDefault();
        try {
            await deleteUserById(userId);
            alert('User deleted successfully!');
        } catch (error) {
            console.error('Error deleting user:', error);
        }
    };

    return (
        <div className="container mt-4">
            <h2>Delete User</h2>
            <form onSubmit={handleDelete}>
                <div className="mb-3">
                    <label className="form-label">User ID</label>
                    <input type="number" className="form-control" value={userId} onChange={(e) => setUserId(e.target.value)} required />
                </div>
                <button type="submit" className="btn btn-danger">Delete User</button>
            </form>
        </div>
    );
};

export default DeleteUser;