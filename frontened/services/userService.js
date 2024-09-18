import axios from 'axios';

const API_BASE_URL = 'http://localhost:5151/api/Users/GetUsers';

// Fetch all users
export const fetchUsers = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}`);
        return response.data;
        
    } catch (error) {
        console.error('Error fetching users:', error);
        throw error;
    }
};

// Add a new user
export const addUser = async (user) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/AddUser`, user, {
            headers: {
                'Content-Type': 'multipart/form-data' // Set correct header
            }
        });
        return response.data;
        console.log(response.data)   
    } catch (error) {
        console.error('Error adding user:', error);
        console.log(error)
        throw error;
    }
};
// Delete user by ID
export const deleteUserById = async (id) => {
    try {
        const response = await axios.delete(`${API_BASE_URL}/DeleteUserById`, { params: { id } });
        return response.data;
    } catch (error) {
        console.error('Error deleting user:', error);
        throw error;
    }
};

// Update phone number by ID
export const updatePhoneNumber = async (id, phoneNumber) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/UpdatePhoneNumber`, null, { params: { id, phonenumber: phoneNumber } });
        return response.data;
    } catch (error) {
        console.error('Error updating phone number:', error);
        throw error;
    }
};