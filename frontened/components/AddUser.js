import React, { useState } from 'react';
import { addUser } from '../services/userService'; // Make sure to implement this API call in userService

const AddUser = () => {
    const [formData, setFormData] = useState({
        name: '',
        dateOfBirth: '',
        residentialAddress: '',
        permanentAddress: '',
        phoneNumber: '',
        emailAddress: '',
        maritalStatus: '',
        gender: '',
        occupation: '',
        aadharCardNumber: '',
        panNumber: '',
        image: '',
        imageFile: null // Store the file object
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleFileChange = (e) => {
        setFormData({
            ...formData,
            imageFile: e.target.files[0] // Capture the selected file
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Create FormData to handle file and text data
        const userFormData = new FormData();
        userFormData.append('name', formData.name);
        userFormData.append('dateOfBirth', formData.dateOfBirth);
        userFormData.append('residentialAddress', formData.residentialAddress);
        userFormData.append('permanentAddress', formData.permanentAddress);
        userFormData.append('phoneNumber', formData.phoneNumber);
        userFormData.append('emailAddress', formData.emailAddress);
        userFormData.append('maritalStatus', formData.maritalStatus);
        userFormData.append('gender', formData.gender);
        userFormData.append('occupation', formData.occupation);
        userFormData.append('aadharCardNumber', formData.aadharCardNumber);
        userFormData.append('panNumber', formData.panNumber);
        userFormData.append('image', "image");
        if (formData.imageFile) {
            userFormData.append('imageFile', formData.imageFile); // Append the image file
        }

        try {
            // Call the API to add the user
            await addUser(userFormData); 
            alert('User added successfully!');
        } catch (error) {
            console.error('Error adding user:', error);
        }
    };

    return (
        <div className="container mt-4">
            <h2>Add User</h2>
            <form onSubmit={handleSubmit} encType="multipart/form-data">
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" name="name" value={formData.name} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Date of Birth</label>
                    <input type="date" className="form-control" name="dateOfBirth" value={formData.dateOfBirth} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Residential Address</label>
                    <input type="text" className="form-control" name="residentialAddress" value={formData.residentialAddress} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Permanent Address</label>
                    <input type="text" className="form-control" name="permanentAddress" value={formData.permanentAddress} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Phone Number</label>
                    <input type="text" className="form-control" name="phoneNumber" value={formData.phoneNumber} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email Address</label>
                    <input type="email" className="form-control" name="emailAddress" value={formData.emailAddress} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Marital Status</label>
                    <select className="form-select" name="maritalStatus" value={formData.maritalStatus} onChange={handleChange} required>
                        <option value="">Select</option>
                        <option value="Single">Single</option>
                        <option value="Married">Married</option>
                        <option value="Divorced">Divorced</option>
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Gender</label>
                    <select className="form-select" name="gender" value={formData.gender} onChange={handleChange} required>
                        <option value="">Select</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Occupation</label>
                    <input type="text" className="form-control" name="occupation" value={formData.occupation} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Aadhar Card Number</label>
                    <input type="text" className="form-control" name="aadharCardNumber" value={formData.aadharCardNumber} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">PAN Number</label>
                    <input type="text" className="form-control" name="panNumber" value={formData.panNumber} onChange={handleChange} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Profile Image</label>
                    <input type="file" className="form-control" name="imageFile" onChange={handleFileChange} required />
                </div>
                <button type="submit" className="btn btn-primary">Add User</button>
            </form>
        </div>
    );
};

export default AddUser;