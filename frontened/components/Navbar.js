import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-success">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">User Management</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link className="nav-link" to="/users">Get-Users</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/add-user">Add-User</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/delete-user">Delete-User</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/update-phone">Update-Phone-Number</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;