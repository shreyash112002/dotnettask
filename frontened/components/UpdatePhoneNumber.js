import React, { useState } from 'react';
import { updatePhoneNumber } from '../services/userService';

const UpdatePhoneNumber = () => {
    const [userId, setUserId] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');

    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            await updatePhoneNumber(userId, phoneNumber);
            alert('Phone number updated successfully!');
        } catch (error) {
            console.error('Error updating phone number:', error);
        }
    };

    return (
        <div className="container mt-4">
            <h2>Update Phone Number</h2>
            <form onSubmit={handleUpdate}>
                <div className="mb-3">
                    <label className="form-label">User ID</label>
                    <input type="number" className="form-control" value={userId} onChange={(e) => setUserId(e.target.value)} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Phone Number</label>
                    <input type="text" className="form-control" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} required />
                </div>
                <button type="submit" className="btn btn-primary">Update Phone Number</button>
            </form>
        </div>
    );
};

export default UpdatePhoneNumber;