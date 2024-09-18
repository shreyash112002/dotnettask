import { BrowserRouter, Route, Routes } from 'react-router-dom';
import UserList from '../components/UserList'
import AddUser from '../components/AddUser'
import DeleteUser from '../components/DeleteUser'
import UpdatePhoneNumber from '../components/UpdatePhoneNumber'
import Navbar from '../components/Navbar';
import MainHome from '../home/MainHome';

const EndPoints = () => {
  return (
    <>
      {/* <BrowserRouter> */}
            <Navbar />
            <div className="container mt-4">
                <Routes>
                    <Route path="/" element={<MainHome/>} />
                    <Route path="/users" element={<UserList />} />
                    <Route path="/add-user" element={<AddUser />} />
                    <Route path="/delete-user" element={<DeleteUser />} />
                    <Route path="/update-phone" element={<UpdatePhoneNumber />} />
                </Routes>
            </div>
        {/* </BrowserRouter> */}
    </>
  )
}

export default EndPoints