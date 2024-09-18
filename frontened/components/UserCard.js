import React from 'react';

const UserCard = ({ user }) => {
    return (
        <div className="card mb-3" style={{ maxWidth: '540px' }}>
            <div className="row g-0">
            <div className="col-md-4">
            <img 
                src={user.image ? user.image : "https://via.placeholder.com/150"} 
                alt={user.name} 
                className="img-fluid rounded-start" 
                width="200" 
                height="150" 
            />
        </div>

                <div className="col-md-8">
                    <div className="card-body">
                        <h5 className="card-title">{user.name}</h5>
                        <p className="card-text"><strong>Phone:</strong> {user.phoneNumber}</p>
                        <p className="card-text"><strong>Email:</strong> {user.emailAddress}</p>
                        <p className="card-text"><strong>Occupation:</strong> {user.occupation}</p>
                        <p className="card-text"><strong>Address:</strong> {user.residentialAddress}</p>
                        <p className="card-text">
                            <small className="text-muted">Marital Status: {user.maritalStatus}</small>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default UserCard;