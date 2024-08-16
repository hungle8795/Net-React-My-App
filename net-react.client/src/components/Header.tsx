import React from 'react';
//import { Link } from 'react-router-dom';

const Header: React.FC = () => {
    return (
        <header>
            {/*<nav>*/}
            {/*    <ul>*/}
            {/*        <li><Link to="/">Home</Link></li>*/}
            {/*        <li><Link to="/cart">Cart</Link></li>*/}
            {/*    </ul>*/}
            {/*</nav>*/}


            <div
                className="navbar navbar-expand-sm bg-dark navbar-dark nav-pills fixed-top justify-content-between pl-5 pt-3 pr-5 pb-3">
                {/*<a className="navbar-logo" href="#logo" id="#logo">*/}
                {/*    <img src="../img/logo-dark.png" />*/}
                {/*</a>*/}
                <h4 className="text-white">ホームページ</h4>
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
                                <input placeholder="検索" className="text-left">
                                    {/*<p className="text-right">tim</p>*/}
                                </input>
                            </form>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link mb-0 mr-3" href="#pricing">サインアップ</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="https://themeforest.net/checkout/82475332/create_account">
                                <button className="btn bg-white text-danger">ログイン</button>
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
        </header>
    );
};

export default Header;
