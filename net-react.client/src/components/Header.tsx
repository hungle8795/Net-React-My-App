import { FC } from 'react';
import '../styles/Header.css';
//import { Link } from 'react-router-dom';

const Header: FC = () => {
    return (
        <div
            className="navbar navbar-expand-sm bg-dark navbar-dark nav-pills fixed-top justify-content-between ps-5 pt-3 pe-5 pb-3">
            {/*<a className="navbar-logo" href="#logo" id="#logo">*/}
            {/*    <img src="../img/logo-dark.png" />*/}
            {/*</a>*/}
            <h4 className="text-white">Home Page</h4>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
                <ul className="navbar-nav align-item-center">
                    {/*<li className="nav-item">*/}
                    {/*    <a className="nav-link mb-0 mr-3" href="#home">HOME</a>*/}
                    {/*</li>*/}
                    {/*<li className="nav-item">*/}
                    {/*    <a className="nav-link mb-0 mr-3" href="#features">FEATURES</a>*/}
                    {/*</li>*/}
                    {/*<li className="nav-item">*/}
                    {/*    <a className="nav-link mb-0 mr-3" href="#portfolio">PORTFOLIO</a>*/}
                    {/*</li>*/}
                    {/*<li className="nav-item">*/}
                    {/*    <a className="nav-link mb-0 mr-3" href="#resume">RESUME</a>*/}
                    {/*</li>*/}
                    {/*<li className="nav-item">*/}
                    {/*    <a className="nav-link mb-0 mr-3" href="#clients">CLIENTS</a>*/}
                    {/*</li>*/}
                    <li className="nav-item">
                        <form className="nav-link mb-0 mr-3" >
                            <input placeholder="Search" className="text-left" />
                            <i className="fa-solid fa-magnifying-glass"></i>
                        </form>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link mb-0 mr-3" href="#pricing">SignUp</a>
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
                        <a className="nav-link" href="#home">
                            <i className="fas fa-chevron-up font-size-30px text-info text-center"></i>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    );
};

export default Header;
