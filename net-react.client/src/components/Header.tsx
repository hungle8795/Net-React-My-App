import { FC } from 'react';
import '../styles/Header.css';
//import { Link } from 'react-router-dom';

const Header: FC = () => {
    return (
        <div
            className="navbar navbar-expand-sm bg-dark navbar-dark nav-pills fixed-top justify-content-between ps-5 pt-3 pe-5 pb-3">
            <a className="text-white navbar-logo" href="#top" id="#top">Home Page</a>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
                <ul className="navbar-nav align-items-center d-flex justify-content-between w-35">
                    <li className="nav-item">
                        <form className="nav-link mb-0 mr-3 bg-white" >
                            <input placeholder="Search" className="text-left border-0 forcus-visible-none" />
                            <i className="fa-solid fa-magnifying-glass text-dark fs-5"></i>
                        </form>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link mb-0 mr-3" href="#signup">SignUp</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="https://themeforest.net/checkout/82475332/create_account">
                            <button className="btn bg-white text-danger">Login</button>
                        </a>
                    </li>
                </ul>
            </div>
            <nav className="navbar navbar-expand-sm navbar-dark mt-5 position-fixed bottom-10px right-10px">
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <a className="nav-link" href="#top">
                            <i className="fas fa-chevron-up font-size-30px text-info text-center"></i>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    );
};

export default Header;
